import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Unit {
    unitId: number;
    name: string;
    semester: string;
}

@Component
export default class FetchUnitsComponent extends Vue {
    units: Unit[] = [];
    
    mounted() {
        fetch('api/Units/')
            .then(response => response.json() as Promise<Unit[]>)
            .then(data => {
                this.units = data;
            });
    }
}
