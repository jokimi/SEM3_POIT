let fun = function (a, b, c = 9) {
    return a + ' ' + b + ' ' + c;
}
let aa = prompt("Введите a: ", '');
let result = fun(aa, 6);
alert(result);