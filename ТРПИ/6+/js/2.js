const user = {
    name: "John",
    age: 30
};
const admin = {
    admin: true,
    ...user
};
console.log(admin);