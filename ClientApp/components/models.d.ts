/* This file contains the interfaces used by the client components */
export interface Student {
    studentId: number;
    firstName: string;
    lastName: string;
}

export interface Unit { 
    unitId: number;
    name: string;
    semester: string;
    weight1: number;
    weight2: number;
    weight3: number;
    enrollments: Enrollment[];
}

export interface Enrollment { 
    grade1: number;
    grade2: number;
    grade3: number;
    student: Student;
}

