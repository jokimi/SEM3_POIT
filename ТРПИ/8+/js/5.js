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
let modifiedStore = {
    ...deepCopy10,
    state: {
        ...deepCopy10.state,
        profilePage: {
            ...deepCopy10.state.profilePage,
            posts: deepCopy10.state.profilePage.posts.map(post => ({
                ...post,
                message: 'Hello'
            }))
        },
        dialogsPage: {
            ...deepCopy10.state.dialogsPage,
            messages: deepCopy10.state.dialogsPage.messages.map(message => ({
                ...message,
                message: 'Hello'
            }))
        }
    }
};
console.log(modifiedStore);