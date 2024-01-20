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
                    const cost = this["cost"];
                    const discount = this["discount"];
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
newProducts["Обувь"]["Ботинки"][0].cost = 100;
newProducts["Обувь"]["Ботинки"][0].discount = 20;
console.log(newProducts["Обувь"]["Ботинки"][0].price);