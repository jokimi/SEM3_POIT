function basicOperation(operation, value1, value2) {
    let result;
    if (operation == '+') {
        result = value1 + value2;
    }
    else if (operation == '-') {
        result = value1 - value2;
    }
    else if (operation == '*') {
        result = value1 * value2;
    }
    else if (operation == '/') {
        result = value1 / value2;
    }
    return result;
}
console.log(basicOperation('+', 5, 10));
console.log(basicOperation('-', 7, 1));
console.log(basicOperation('*', 5, 8));
console.log(basicOperation('/', 48, 6));