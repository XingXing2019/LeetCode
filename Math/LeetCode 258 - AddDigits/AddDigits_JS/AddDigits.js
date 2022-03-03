/**
 * @param {number} num
 * @return {number}
 */
var addDigits = function (num) {
    while (num >= 10) {
        var temp = 0
        while (num != 0) {
            temp += num % 10
            num = ~~(num / 10)
        }
        num = temp
    }
    return num
}
