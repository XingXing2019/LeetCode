/**
 * @param {number} num
 * @return {number}
 */
var maximum69Number = function(num) {
    var digits = []
    while (num != 0) {
        digits.push(num % 10)
        num = ~~(num / 10)
    }
    for (let i = digits.length - 1; i >= 0; i--) {
        if (digits[i] != 6) continue
        digits[i] = 9
        break
    }
    var res = 0, pow = 1
    for (let i = 0; i < digits.length; i++) {
        res = res + digits[i] * pow
        pow *= 10
    }
    return res
}