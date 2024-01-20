function createTower(numFloors) {
    const tower = [];
    for (let i = 0; i < numFloors; i++) {
        const spaces = ' '.repeat(numFloors - i - 1);
        const stars = '*'.repeat(2 * i + 1);
        const floor = spaces + stars + spaces;
        tower.unshift(floor);
    }
    return tower;
}
let layer = prompt("Введите количество этажей:", "");
let tower = createTower(layer);
console.log(tower);