import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Student } from '../models'
import { SnotifyToast } from 'vue-snotify/components/SnotifyToast/toast.model';

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
                this.$snotify.success('The student was added successfully');
                this.clear();
            }, () => this.$snotify.error('Oops! Something went wrong.'))
    }

    //TODO: add confirmation
    removeStudent(index:number){
        var studentToRemove = this.students[index];
        fetch('api/students/'+studentToRemove.studentId+'/remove', { 
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json() as Promise<number>)
            .then((returnCode) => {
                this.$snotify.success('The student was removed successfully');
                //remove student from view
                this.students.splice(index,1);
            }, () => this.$snotify.error('Oops! Something went wrong.'))
    }

    clear(){
        this.newStudent.firstName = '';
        this.newStudent.lastName = '';
    }
}
