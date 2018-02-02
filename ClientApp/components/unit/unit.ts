import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

//kind of a hack but there's not enough documentation 
interface Unit { 
    name: string;
    weight1: number;
    weight2: number;
    weight3: number;
    enrollments: Enrollment[];
}
interface Enrollment { 
    grade1: number;
    grade2: number;
    grade3: number;
}

@Component
export default class UnitComponent extends Vue {
    //type assertion to avoid building an empty object
    //since it will be replaced anyways by the fetched data
    unit = <Unit>{}

    mounted() {
        fetch('api/units/'+this.$route.params.id)
            .then(response => response.json() as Promise<Unit>)
            .then(data => {
                this.unit = data;
            });
    }

    //weighted average per Enrollment
    weightedAvg(e: Enrollment ) {
        var wAvg = e.grade1 * this.unit.weight1 + 
            e.grade2 * this.unit.weight2 +
            e.grade3 * this.unit.weight3;

        //one decimal place
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
