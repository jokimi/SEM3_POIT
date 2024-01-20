function reverseAndDelete(str, func) {
    let chars = str.split('');
    let left = 0;
    let right = chars.length - 1;
    while (left < right) {
        func(chars, left, right);
        left++;
        right--;
    }
    return chars.join('').replace(/[^a-zA-Z]/g, '');
}
console.log(reverseAndDelete('Hel+lo,слово Woяrld!', func));
function func(chars, left, right) {
    let temp = chars[left];
    chars[left] = chars[right];
    chars[right] = temp;
}