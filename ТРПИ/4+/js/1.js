let products = new Set();
function addProduct(product) {
    products.add(product);
}
function removeProduct(product) {
    products.delete(product);
}
function hasProduct(product) {
    return products.has(product);
}
function getProductCount() {
    return products.size;
}
addProduct("Макароны");
addProduct("Гречка");
addProduct("Рис");

console.log(getProductCount());
console.log(hasProduct("Гречка"));
removeProduct("Макароны");
console.log(getProductCount());
console.log(hasProduct("Макароны"));