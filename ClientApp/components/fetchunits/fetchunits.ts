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
                this.units.push(newUnit) 
                //TODO: clear controls after post HERE
                return true
                //TODO: add feedback to user after error
            }, () => console.log('error papi'))
    }
}
