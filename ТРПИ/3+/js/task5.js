function extend(...objects) {
    return Object.assign({}, ...objects);
}
console.log(extend({a: 1, b: 2}, {c: 3}));
console.log(extend({a: 1, b: 2}, {c: 3}, {d: 4}));
console.log(extend({a: 1, b: 2}, {a: 3, c: 3}));