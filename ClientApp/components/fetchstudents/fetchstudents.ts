import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Student } from '../models'
import { SnotifyToast } from 'vue-snotify/components/SnotifyToast/toast.model';

@Component
export default class FetchStudentsComponent extends Vue {
    students: Student[] = [];
    newStudent  = <Student>{};
    succesfulAdd = false;
    studentToRemoveIndex =  -1;
    
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
                this.$snotify.success('The student was added successfully');
                this.clear();
            }, () => this.$snotify.error('Oops! Something went wrong.'))
    }

    //marks a student for removal
    //used for confirmation purposes
    confirmRemove(index:number){
        this.studentToRemoveIndex = index;
    }

    //removes the studen marked for removal
    removeStudent(){
        fetch('api/students/' + this.studentToRemove.studentId + '/remove', { 
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json() as Promise<number>)
            .then((returnCode) => {
                this.$snotify.success('The student was deleted successfully');
                //remove student from view
                this.students.splice(this.studentToRemoveIndex, 1);
            }, () => this.$snotify.error('Oops! Something went wrong.'))
    }

    get studentToRemove(){
        var student = this.students[this.studentToRemoveIndex];
        //this will avoid null errors when loading
        //the page for the first time and after deleting a user
        return student == undefined ? <Student>{} : student;
    }

    clear(){
        this.newStudent.firstName = '';
        this.newStudent.lastName = '';
    }
}
