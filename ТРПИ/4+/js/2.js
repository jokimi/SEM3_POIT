let students = new Set();
function addStudent(student) {
    students.add(student);
}
function removeStudent(studentId) {
    students.forEach(function(student) {
        if (student.studentId === studentId) {
            students.delete(student);
            return;
        }
    });
}
function filterStudentsByGroup(group) {
    let filteredStudents = new Set();
    students.forEach(function(student) {
        if (student.group === group) {
            filteredStudents.add(student);
        }
    });
    return filteredStudents;
}
function sortStudentsByStudentId() {
    let sortedStudents = Array.from(students);
    sortedStudents.sort(function(a, b) {
        return a.studentId - b.studentId;
    });
    return sortedStudents;
}

let student1 = { studentId: 123, group: 'Группа 1', name: 'Иванов Иван Иванович' };
let student2 = { studentId: 456, group: 'Группа 2', name: 'Петров Петр Петрович' };
let student3 = { studentId: 789, group: 'Группа 3', name: 'Алексеев Алексей Алексеевич' };
let student4 = { studentId: 111, group: 'Группа 1', name: 'Сергеев Сергей Сергеевич' };
let student5 = { studentId: 744, group: 'Группа 2', name: 'Павлов Павел Павлович' };
let student6 = { studentId: 539, group: 'Группа 1', name: 'Семенов Семен Семенович' };
let student7 = { studentId: 731, group: 'Группа 3', name: 'Борисов Борис Борисович' };
let student8 = { studentId: 952, group: 'Группа 2', name: 'Антонов Антон Антонович' };
let student9 = { studentId: 333, group: 'Группа 1', name: 'Максимов Максим Максимович' };

addStudent(student1);
addStudent(student2);
addStudent(student3);
addStudent(student4);
addStudent(student5);
addStudent(student6);
addStudent(student7);
addStudent(student8);
addStudent(student9);
console.log(students.size);
removeStudent(456);
removeStudent(952);
console.log(students.size);
let filteredStudents = filterStudentsByGroup('Группа 1');
console.log(filteredStudents);
let sortedStudents = sortStudentsByStudentId();
console.log(sortedStudents);