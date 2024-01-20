function sumValues(x, y, z) {
    return x + y + z;
}
const arr = [1, 2, 3];
const sum = sumValues(...arr);
console.log(sum);