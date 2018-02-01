import Vue from 'vue';
import { Component } from 'vue-property-decorator';
//import { URLSearchParams } from 'url';

interface Student {
    studentId: number;
    firstName: string;
    lastName: string;
}

@Component
export default class FetchStudentsComponent extends Vue {
    students: Student[] = [];
    newStudent: Student = { studentId: 0, firstName: '', lastName: ''};
    
    mounted() {
        fetch('api/Students/')
            .then(response => response.json() as Promise<Student[]>)
            .then(data => {
                this.students = data;
            });
    }

    addStudent() {
        fetch('api/SampleData/PruebaPost', { 
            method: 'POST',
            body: JSON.stringify(this.newStudent),
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json() as Promise<Student>)
            .then(newStudent => this.students.push(newStudent));

    }
}
