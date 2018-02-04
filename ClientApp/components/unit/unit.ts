import Vue from 'vue';
import { Component, Watch } from 'vue-property-decorator';

import { Unit, Enrollment, Student } from '../models';

@Component
export default class UnitComponent extends Vue {
    //type assertions to avoid building an empty object
    //since it will be replaced anyways by the fetched data
    //this will remove "undefined property warnings" by Vue
    unit = <Unit>{ enrollments: <Enrollment[]>{ } };
    initialState = <Enrollment[]>{};
    currentEnrollment = <Enrollment> { student: <Student>{} };
    // used to detect changes to the grades
    // since loading the data for the first time will trigger
    // the watch property, we will initialize, it starts as -1
    changes: number = -1;
    lastOperationReturnCode: number = 1;
    
    mounted() {
        fetch('api/units/'+this.$route.params.id)
            .then(response => response.json() as Promise<Unit>)
            .then(data => {
                this.unit = data;
                // to avoid errors, the current enrollment will be the first
                // TODO: check if null would be better
                this.currentEnrollment = this.unit.enrollments[0];
            });
    }

    @Watch('unit.enrollments', { deep: true } )
    onUnitChange(val: Enrollment[], oldVal: Enrollment[]){
        this.changes += 1;
        if(this.changes == 0){
            this.initialState = this.copyState();
        }
    }

    revertChanges(){
        this.unit.enrollments = this.initialState;
        //onUnitChange will change this to 0, which = no changes
        this.changes = -1;
    }

    get successfulSave(){
        return this.lastOperationReturnCode == 0;
    }

    get failedSave(){
        return this.lastOperationReturnCode == -1;
    }

    applyChanges(){
        fetch('api/units/Update', { 
            method: 'POST',
            body: JSON.stringify(this.unit),
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json() as Promise<number>)
            .then(returnCode => {
                if(returnCode == 0){
                    this.lastOperationReturnCode = 0;
                    this.initialState = this.unit.enrollments
                    this.changes = -1;
                }
            }, () => this.lastOperationReturnCode = -1)
    }

    get IsThereChanges(){
        return this.changes > 0;
    }

    // returns a deep copy of the unit.Enrollments array
    // for state-keeping purposes
    copyState(){
        return this.unit.enrollments.map(obj => ({...obj}));
    }

    //MAYBE: add 
    editEnrollment(index: number){
        this.currentEnrollment = this.unit.enrollments[index];
    }

    fullName(s: Student){
        return s.firstName + ' ' + s.lastName;
    }

    //weighted average per Enrollment
    weightedAvg(e: Enrollment ) {
        var wAvg = e.grade1 * this.unit.weight1 + 
            e.grade2 * this.unit.weight2 +
            e.grade3 * this.unit.weight3;

        return wAvg;
    }

    //TODO: Put this in a separate helper file
    formatDecimal(n: number, decimalPlaces: number){
        return (Math.round(n * 100) / 100).toFixed(decimalPlaces);
    }

    //unit average
    unitAvg(){
        var sum = 0.0
        for(var e of this.unit.enrollments){
            sum += this.weightedAvg(e);
        }
        return sum / this.unit.enrollments.length;
    }
}
