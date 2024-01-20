const cache = new WeakMap();
function expensiveFunction(param) {
    const cachedResult = cache.get(param);
    if (cachedResult !== undefined) {
        return cachedResult;
    }
    else {
        const result = Number(param.key) * 2;
        cache.set(param, result);
        return result;
    }
}

const param1 = { key: 5 };
console.log(expensiveFunction(param1));
console.log(expensiveFunction(param1));
const param2 = { key: 10 };
console.log(expensiveFunction(param2));
console.log(expensiveFunction(param2));