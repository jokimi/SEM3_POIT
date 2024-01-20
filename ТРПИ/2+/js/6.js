let arr1 = ['hi', 'morning', 'lemon', 'plant'];
let arr2 = ['cup', 'hi', 'plant', 'lime', 'fruit'];
function compare(arr1, arr2) {
    const arr3 = arr1.filter(n => !arr2.includes(n));
    return arr3;
}
console.log(compare(arr1, arr2));