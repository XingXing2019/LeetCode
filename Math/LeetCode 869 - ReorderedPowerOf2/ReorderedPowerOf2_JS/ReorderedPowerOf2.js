/**
 * @param {number} n
 * @return {boolean}
 */
var reorderedPowerOf2 = function (n) {
    var isMatch = function(num, power) {
        var digits = new Array(10).fill(0)
        while (num != 0) {
            digits[num % 10]++
            num = ~~(num / 10)
        }
        while (power != 0) {
            digits[power % 10]--
            power = ~~(power / 10)
        }
        return !digits.some(x => x != 0)
    }
    var power = 1
    for (let i = 0; i < 31; i++) {
        if (isMatch(n, power))
            return true
        power *= 2
    }
    return false
}


