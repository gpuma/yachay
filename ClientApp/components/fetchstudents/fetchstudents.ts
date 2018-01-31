import Vue from 'vue';
import { Component } from 'vue-property-decorator';
//import { URLSearchParams } from 'url';

interface Student {
    cui: string;
    firstName: string;
    lastName: string;
}

interface Blog{
    blogId: number;
    url: string;
}

@Component
export default class FetchStudentsComponent extends Vue {
    students: Blog[] = [];
    //students: Student[] = [];
    //newStudent: Student = {cui: "", firstName: "", lastName: ""};
    newStudent: Blog = {blogId: 0, url: ""};
    
    mounted() {
        fetch('api/SampleData/Students')
            .then(response => response.json() as Promise<Blog[]>)
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
            .then(res => res.json() as Promise<Blog>)
            .then(newStudent => this.students.push(newStudent));

    }
}
