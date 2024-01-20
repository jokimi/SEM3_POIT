function getAverage(array) {
    if (array.length === 0) {
        return 0;
    }
    var sum = 0;
    for (let i = 0; i < array.length; i++) {
        sum += array[i];
    }
    let average = sum / array.length;
    return average;
}
let numbers = [80, 77, 88, 95, 68];
let result = getAverage(numbers);
console.log(result);