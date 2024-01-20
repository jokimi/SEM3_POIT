function calculateTotal(string) {
    let total1 = 0;
    let total2 = 0;
    for (let i = 0; i < string.length; i++) {
        total1 += string.charCodeAt(i).toString();
    }
    total1 = parseInt(total1).toString();
    console.log(total1);
    total2 = total1.toString().replace(/7/g, '1');
    total2 = parseInt(total2).toString();
    console.log(total2);
    let result = total1 - total2;
    return result;
}
let inputString = 'ABC';
let output = calculateTotal(inputString);
console.log(output);