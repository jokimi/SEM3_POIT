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
for (const category in products) {
    for (const type in products[category]) {
        const shoes = products[category][type];
        for (const shoe of shoes) {
            Object.defineProperty(shoe, "price", {
                writable: true,
                enumerable: true,
                configurable: false,
            });
            Object.defineProperty(shoe, "id", {
                writable: false,
                enumerable: true,
                configurable: false,
            });
        }
    }
}
products["Обувь"]["Ботинки"][0].price = 80; // Можно изменить цену
delete products["Обувь"]["Ботинки"][0].id; // Нельзя удалить номер товара
console.log(products["Обувь"]["Ботинки"][0].price);
console.log(products["Обувь"]["Ботинки"][0].id);