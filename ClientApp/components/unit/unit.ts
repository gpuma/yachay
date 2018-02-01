import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

//kind of a hack but there's not enough documentation 
interface Unit { }

@Component
export default class UnitComponent extends Vue {
    unit: Unit = { };

    mounted() {
        fetch('api/units/'+this.$route.params.id)
            .then(response => response.json() as Promise<Unit>)
            .then(data => {
                this.unit = data;
            });
    }
}
