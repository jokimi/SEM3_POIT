let arr = [1, [1, 2, [3, 4]], [2, 4]];
const intersection = (arr) => {
    return arr.reduce((a, e) => a + e, [])
}
console.log(intersection([arr]));