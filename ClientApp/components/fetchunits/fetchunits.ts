import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Unit } from '../models';

@Component
export default class FetchUnitsComponent extends Vue {
    units: Unit[] = [];
    newUnit: Unit = <Unit>{};
    
    mounted() {
        fetch('api/Units/')
            .then(response => response.json() as Promise<Unit[]>)
            .then(data => {
                this.units = data;
            });
    }
    addUnit() {
        fetch('api/units/add', { 
            method: 'POST',
            body: JSON.stringify(this.newUnit),
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json() as Promise<Unit>)
            .then(newUnit => {
                this.$snotify.success('The unit was added successfully');
                this.units.push(newUnit);
                this.clear();
            }, () => this.$snotify.error('Oops! Something went wrong.'))
    }

    //TODO: add confirmation
    removeUnit(index:number){
        var unitToRemove = this.units[index];
        fetch('api/units/'+unitToRemove.unitId+'/remove', { 
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json() as Promise<number>)
            .then((returnCode) => {
                this.$snotify.success('The unit was removed successfully');
                this.units.splice(index,1);
            }, () => this.$snotify.error('Oops! Something went wrong.'))
    }

    clear(){
        this.newUnit = <Unit>{};
    }
}
