import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Student } from '../models'

@Component
export default class FetchStudentsComponent extends Vue {
    students: Student[] = [];
    newStudent  = <Student>{};
    succesfulAdd: boolean = false;
    
    mounted() {
        fetch('api/Students/')
            .then(response => response.json() as Promise<Student[]>)
            .then(data => {
                this.students = data;
            });
    }

    addStudent() {
        fetch('api/Students/Add', { 
            method: 'POST',
            body: JSON.stringify(this.newStudent),
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json() as Promise<Student>)
            .then(newStudent => {
                this.students.push(newStudent) 
                //TODO: clear controls after post HERE
                this.$snotify.success('Example body content', {
                    timeout: 2000,
                    showProgressBar: false,
                    closeOnClick: false,
                    pauseOnHover: true
                  });
            }, () => console.log('error papi'))
    }
}
