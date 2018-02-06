import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Student } from '../models'

@Component
export default class EnrollStudentsComponent extends Vue {
    students: Student[] = [];
    // newStudent: Student = { studentId: 0, firstName: '', lastName: ''};
    // succesfulAdd: boolean = false;
    
    mounted() {
        fetch('api/units/'+ this.$route.params.id + '/enroll')
            .then(response => response.json() as Promise<Student[]>)
            .then(data => {
                this.students = data;
            });
    }

    enrollStudents() {
        console.log(this.studentsToEnroll.length);
        fetch('api/units/'+ this.$route.params.id + '/ConfirmEnrollment', { 
            method: 'POST',
            body: JSON.stringify(this.studentsToEnroll),
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json() as Promise<number>)
            .then(returnCode => {
                if(returnCode == 0){
                    this.students = this.remainingStudents;
                    this.$snotify.success('Enrollment was successful.');
                }
            }, () => this.$snotify.error('Oops! Something went wrong.'))
    }

    get studentsToEnroll(){
        return this.students.filter(s => s.enroll);
    }

    // the opposite of the above property
    // used to update the state after a successful enrollment
    get remainingStudents(){
        return this.students.filter(s => !s.enroll);
    }
}
