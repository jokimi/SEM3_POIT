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
function Shoe(id, size, color, price) {
    this.id = id;
    this.size = size;
    this.color = color;
    this.price = price;
}
const boots1 = new Shoe(1, 39, "черный", 100);
const boots2 = new Shoe(2, 40, "коричневый", 120);
const sneakers1 = new Shoe(3, 41, "синий", 80);
const sneakers2 = new Shoe(4, 42, "красный", 90);
const sandals1 = new Shoe(5, 38, "белый", 60);
const sandals2 = new Shoe(6, 37, "розовый", 70);
console.log(boots1);
console.log(boots2);
console.log(sneakers1);
console.log(sneakers2);
console.log(sandals1);
console.log(sandals2);