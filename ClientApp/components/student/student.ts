import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import { Enrollment} from '../models';

@Component
export default class StudentComponent extends Vue {
    
    enrollments = <Enrollment[]>{};
    
    mounted() {
        fetch('api/students/'+this.$route.params.id)
            .then(response => response.json() as Promise<Enrollment[]>)
            .then(data => {
                this.enrollments = data;
            });
    }
}
