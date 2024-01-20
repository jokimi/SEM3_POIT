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
            { id: 5, size: 40, color: "коричневый", price: 110 },
            { id: 6, size: 37, color: "розовый", price: 70 },
        ],
    },
};
function filterShoesByCriteria(priceRange, size, color) {
    const category = "Обувь";
    const matchingIds = [];
    for (const type in this[category]) {
        const shoes = this[category][type];
        for (const shoe of shoes) {
            if ((shoe.price >= priceRange.minPrice && shoe.price <= priceRange.maxPrice) && shoe.size === size && shoe.color === color) {
                matchingIds.push(shoe.id);
            }
        }
    }
    return matchingIds;
}
const criteria = {
    priceRange: { minPrice: 90, maxPrice: 120 },
    size: 40,
    color: "коричневый",
};
const matchingIds = filterShoesByCriteria.call(products, criteria.priceRange, criteria.size, criteria.color);
console.log(matchingIds);