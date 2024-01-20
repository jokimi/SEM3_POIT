var myVariable = 'Hello';
var anotherVariable = 'World';

function myFunction() {
  console.log('This is a function');
}

// Получение значений переменных и функций из глобального объекта
const globalVariables = Object.keys(window);

globalVariables.forEach(variable => {
  console.log(variable + ':', window[variable]);
});

// Переопределение переменных через глобальный объект
window.myVariable = 'Привет';
window.anotherVariable = 'Мир';

console.log(myVariable);
console.log(anotherVariable);