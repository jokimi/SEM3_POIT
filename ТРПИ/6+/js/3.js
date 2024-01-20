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
let {
    state: {
        profilePage: { posts },
        dialogsPage: { dialogs, messages },
    },
} = store;
const likesCountArray = posts.map((post) => post.likesCount);
console.log(likesCountArray);
const filteredDialogs = dialogs.filter((dialog) => dialog.id % 2 === 0);
console.log(filteredDialogs);
const updatedMessages = messages.map((message) => "Hello user");
console.log(updatedMessages);