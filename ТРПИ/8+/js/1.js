let user = {
    name: 'Masha',
    age: 21
};
let deepCopy1 = { ...user };
console.log(deepCopy1);

let numbers = [1, 2, 3];
let deepCopy2 = [ ...numbers ];
console.log(deepCopy2);

let user1 = {
    name: 'Masha',
    age: 23,
    location: {
        city: 'Minsk',
        country: 'Belarus'
    }
};
let deepCopy3 = {
    ...user1,
    location: { ...user1.location }
};
console.log(deepCopy3);

let user2 = {
    name: 'Masha',
    age: 28,
    skills: ["HTML", "CSS", "JavaScript", "React"]
};
let deepCopy4 = { ...user2 };
console.log(deepCopy4);

const array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
let deepCopy5 = array.map(obj => ({ ...obj }));
console.log(deepCopy5);

let user4 = {
    name: 'Masha',
    age: 19,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        exams: {
            maths: true,
            programming: false
        }
    }
};
let deepCopy6 = {
    ...user4,
    studies: {
        ...user4.studies,
        exams: { ...user4.studies.exams }
    }
};
console.log(deepCopy6);

let user5 = {
    name: 'Masha',
    age: 22,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        department: {
            faculty: 'FIT',
            group: 10,
        },
        exams: [
            { maths: true, mark: 8 },
            { programming: true, mark: 4 },
        ]
    }
};
let deepCopy7 = {
    ...user5,
    studies: {
        ...user5.studies,
        department: { ...user5.studies.department },
        exams: user5.studies.exams.map(exam => ({
            ...exam
        }))
    }
};
console.log(deepCopy7);

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
user6.studies.exams[0].professor.name = 'Maria Ivanova';
console.log(user6);

let user7 = {
    name: 'Masha',
    age: 20,
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
                maths: true,
                mark: 8,
		        professor: {
		            name: 'Ivan Petrov',
		            degree: 'PhD',
		            articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		        }
	        },
            { 
                programming: true,
                mark: 10,
		        professor: {
		            name: 'Petr Ivanov',
		            degree: 'PhD',
		            articles: [
                        {title: "About HTML", pagesNumber: 3},
                        {title: "About CSS", pagesNumber: 5},
                        {title: "About JavaScript", pagesNumber: 1},
                    ]
		        }
	        },
        ]
    }
};
let deepCopy9 = {
    ...user7,
    studies: {
        ...user7.studies,
        department: { ...user7.studies.department },
        exams: user7.studies.exams.map(exam => ({
            ...exam,
            professor: {
                ...exam.professor,
                articles: [...exam.professor.articles]
            },
        }))
    }
};
console.log(deepCopy9);

let store = {
    state: {
        profilePage: {
            posts: [
                { id: 1, message: 'Hi', likesCount: 12 },
                { id: 2, message: 'By', likesCount: 1 },
            ],
            newPostText: 'About me',
        },
        dialogsPage: {
            dialogs: [
                { id: 1, name: 'Valera' },
                { id: 2, name: 'Andrey' },
                { id: 3, name: 'Sasha' },
                { id: 4, name: 'Viktor' },
            ],
            messages: [
                { id: 1, message: 'hi' },
                { id: 2, message: 'hi hi' },
                { id: 3, message: 'hi hi hi' },
            ],
        },
        sidebar: [],
    },
};
let deepCopy10 = {
    ...store,
    state: {
        ...store.state,
        profilePage: {
            ...store.state.profilePage,
            posts: [...store.state.profilePage.posts],
        },
        dialogsPage: {
            ...store.state.dialogsPage,
            dialogs: [...store.state.dialogsPage.dialogs],
            messages: [...store.state.dialogsPage.messages],
        },
    },
};
console.log(deepCopy10);