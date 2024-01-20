function findVolume(length) {
    return function(width) {
        return function(height) {
            return length * width * height;
        }
    }
}
const calculateVolume = findVolume(5);
console.log(calculateVolume);
const volume = calculateVolume(2)(3);
console.log(volume);