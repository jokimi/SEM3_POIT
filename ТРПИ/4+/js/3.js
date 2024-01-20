let products = new Map();

function addProduct(id, name, quantity, price) {
    let product = { 
        id: id,
        name: name,
        quantity: quantity,
        price: price
    };
    products.set(id, product);
}
function removeProductById(id) {
    products.delete(id);
}
function removeProductsByName(name) {
    products.forEach(function(product, key) {
        if (product.name === name) {
            products.delete(key);
        }
    });
}
function updateQuantity(id, newQuantity) {
    let product = products.get(id);
    if (product) {
        product.quantity = newQuantity;
    }
}
function updatePrice(id, newPrice) {
    let product = products.get(id);
    if (product) {
        product.price = newPrice;
    }
}
function getProductCount() {
    return products.size;
}
function getTotalPrice() {
    let totalPrice = 0;
    products.forEach(function(product) {
        totalPrice += product.quantity * product.price;
    });
    return totalPrice;
}

addProduct(1, 'Макароны', 25, 100);
addProduct(2, 'Гречка', 20, 150);
addProduct(3, 'Рис', 27, 200);
addProduct(4, 'Яблоки', 59, 50);
addProduct(5, 'Пельмени', 33, 120);
addProduct(6, 'Шоколад', 42, 200);
addProduct(7, 'Соевый соус', 18, 300);
addProduct(8, 'Огурцы', 67, 70);
addProduct(9, 'Пепси', 39, 240);

console.log(getProductCount());
removeProductById(2);
console.log(getProductCount());
removeProductsByName('Макароны');
console.log(getProductCount())
updateQuantity(3, 140);
console.log(products.get(3).quantity);
updatePrice(4, 250);
console.log(products.get(5).price);
console.log(getTotalPrice());