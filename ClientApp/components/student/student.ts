import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import { Enrollment, Student } from '../models';

@Component
export default class StudentComponent extends Vue {
    student = <Student>{};
    
    mounted() {
        fetch('api/students/'+this.$route.params.id)
            .then(response => response.json() as Promise<Student>)
            .then(data => {
                this.student = data;
            });
    }
}
