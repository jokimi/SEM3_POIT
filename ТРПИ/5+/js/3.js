function* moveObject() {
    let x = 0;
    let y = 0;
    while (true) {
        const direction = yield [x, y];
        switch (direction) {
            case 'l':
                x -= 10;
                break;
            case 'r':
                x += 10;
                break;
            case 'u':
                y += 10;
                break;
            case 'd':
                y -= 10;
                break;
            default:
                console.log('Неверная команда!');
        }
    }
}
const generator = moveObject();
console.log('Начальные координаты:', generator.next().value);
for (let i = 0; i < 10; i++) {
    const direction = prompt('Введите команду (l - left, r - right, u - up, d - down):');
    const coordinates = generator.next(direction).value;
    console.log('Координаты:', coordinates);
}