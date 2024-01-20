let userSurname = 'Кудлацкая';
let userName = 'Марина';
let userPatronymic = 'Федоровна';
enterName = prompt('Введите имя: ', '');
if (enterName == userName || 
    enterName == userName.toUpperCase() || 
    enterName == (userName + ' ' + userPatronymic) || 
    enterName == (userName + ' ' + userPatronymic).toUpperCase() || 
    enterName == (userSurname + ' ' + userName + ' ' + userPatronymic) || 
    enterName == (userSurname + ' ' + userName + ' ' + userPatronymic).toUpperCase()
    ) {
    alert('Данные введены верно!');
}
else {
    alert('Попробуйте еще раз!');
}