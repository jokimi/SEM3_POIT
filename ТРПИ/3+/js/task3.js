function filterStudentsByAge(students) {
    const filteredStudents = {};
    students.forEach(student => {
        if (student.age > 17) {
            if (filteredStudents.hasOwnProperty(student.groupId)) {
                filteredStudents[student.groupId].push(student);
            }
            else {
                filteredStudents[student.groupId] = [student];
            }
        }
    });
    return filteredStudents;
}
let students = [
    { name: 'Иван', age: 18, groupId: 4, },
    { name: 'Алина', age: 20, groupId: 2 },
    { name: 'Борис', age: 16, groupId: 1 },
    { name: 'Ева', age: 19, groupId: 2 },
    { name: 'Николай', age: 21, groupId: 3 },
    { name: 'Катя', age: 17, groupId: 3 }
];
const filteredStudents = filterStudentsByAge(students);
console.log(filteredStudents);