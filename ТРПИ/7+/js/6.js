const products = {
    "Обувь": {
        "Ботинки": [
            { id: 1, size: 39, color: "черный", price: 100 },
            { id: 2, size: 40, color: "коричневый", price: 120 },
         ],
        "Кроссовки": [
            { id: 3, size: 41, color: "синий", price: 80 },
            { id: 4, size: 42, color: "красный", price: 90 },
        ],
        "Сандалии": [
            { id: 5, size: 38, color: "белый", price: 60 },
            { id: 6, size: 37, color: "розовый", price: 70 },
        ],
    },
};
const newProducts = { ...products };
for (const category in newProducts) {
    for (const type in newProducts[category]) {
        const shoes = newProducts[category][type];
        for (const shoe of shoes) {
            Object.defineProperty(shoe, "price", {
                get() {
                    const cost = this["cost"] || 0;
                    const discount = this["discount"] || 0;
                    return cost - (discount / 100 * cost);
                },
                set(value) {
                    this["price"] = value;
                },
                enumerable: true,
                configurable: true,
            });
        }
    }
}
function Shoe(id, size, color, cost, discount) {
    this.id = id;
    this.size = size;
    this.color = color;
    this.price = cost - discount / 100 * cost;
}
const allProducts = {};
for (const category in newProducts) {
    allProducts[category] = {};
    for (const type in newProducts[category]) {
        allProducts[category][type] = [];
        const shoes = newProducts[category][type];
        for (const shoe of shoes) {
            const newShoe = new Shoe(shoe.id, shoe.size, shoe.color, shoe.price);
            allProducts[category][type].push(newShoe);
        }
    }
}
const boots1 = new Shoe(1, 39, "черный", 100, 20);
const boots2 = new Shoe(2, 40, "коричневый", 120, 10);
const sneakers1 = new Shoe(3, 41, "синий", 80, 0);
const sneakers2 = new Shoe(4, 42, "красный", 90, 25);
const sandals1 = new Shoe(5, 38, "белый", 60, 5);
const sandals2 = new Shoe(6, 37, "розовый", 70, 40);
console.log(boots1);
console.log(boots2);
console.log(sneakers1);
console.log(sneakers2);
console.log(sandals1);
console.log(sandals2);