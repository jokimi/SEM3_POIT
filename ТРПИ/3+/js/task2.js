function arraySum(arr) {
    let sum = 0;
    arr.map((item) => {
        if (Array.isArray(item)) {
            sum += arraySum(item);
        }
        else {
            sum += item;
        }
    });
    return sum;
}
console.log(arraySum([[1, 2, [3, 4]], [9], [10, 12]]));