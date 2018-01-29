import Vue from 'vue';
import { Component } from 'vue-property-decorator';
//import { URLSearchParams } from 'url';

interface Student {
    cui: string;
    firstName: string;
    lastName: string;
}

@Component
export default class FetchStudentsComponent extends Vue {
    students: Student[] = [];
    firstName: string;
    lastName: string;
    cui: string;
    rpta: number;
    
    mounted() {
        fetch('api/SampleData/Students')
            .then(response => response.json() as Promise<Student[]>)
            .then(data => {
                this.students = data;
            });
    }

    addStudent() {
        // fetch('api/SampleData/Students')
        //     .then(response => response.json() as Promise<number>)
        //     .then(data => {
        //         this.rpta = data;
        //     });
        var data = {
            // good news, it's not case sensitive!
            "cui": this.cui,
            "firstName": this.firstName,
            "lastName": this.lastName,
        }
        console.log(data);
        //const params = new URLSearchParams();
        //console.log(params);
        fetch('api/SampleData/PruebaPost', { 
            method: 'POST',
            body: JSON.stringify(data),
            headers: { 'Content-Type': 'application/json' },
        })
            .then(res => res.json())
            .then(json => console.log(json));

    }
}
