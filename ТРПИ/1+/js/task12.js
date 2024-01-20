let a = 7;
let b = 6;
function params(a, b) {
    if (a == b) {
        console.log(a * 4);
    }
    else {
        console.log(a * b);
    }
}
params(a, b);

let aa = 4;
let bb = 9;
let getParam = function params(aa, bb) {
    if (aa == bb) {
        console.log(aa * 4);
    }
    else {
        console.log(aa * bb);
    }
}
getParam(aa, bb);

let aaa = 8;
let bbb = 8;
let param = (aaa == bbb) ?
    () => console.log(aaa * 4) :
    () => console.log(aaa * bbb);
param();