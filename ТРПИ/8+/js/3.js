let user6 = {
    name: 'Masha',
    age: 21,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            { 
                maths: true, mark: 8,
		        professor: {
		            name: 'Ivan Ivanov ',
		            degree: 'PhD'
		        }
	        },
            { 
                programming: true, mark: 10,
		        professor: {
		            name: 'Petr Petrov',
		            degree: 'PhD'
		        }
	        },
        ]
    }
};
let deepCopy8 = {
    ...user6,
    studies: {
        ...user6.studies,
        department: { ...user6.studies.department },
        exams: user6.studies.exams.map(exam => ({
            ...exam,
            professor: { ...exam.professor }
        }))
    }
};
deepCopy8.studies.exams[1].professor.name = 'Sergey Sergeev';
console.log(deepCopy8);