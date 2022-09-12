/**
 * @param {number} num
 * @return {number}
 */
var maximumSwap = function(num) {
    var swap = function (digits, index) {
        for (let i = 0; i < index; i++) {
            if (digits[i] >= digits[index]) continue
            var temp = digits[i]
            digits[i] = digits[index]
            digits[index] = temp
            break
        }
        var res = 0
        for (let i = 0; i < digits.length; i++)
            res = res * 10 + digits[i]
        return res
    }
    var res = num
    var digits = []
    while (num != 0) {
        digits.unshift(num % 10)
        num = ~~(num / 10)
    }
    for (let i = 0; i < digits.length; i++)
        res = Math.max(res, swap([...digits], i))
    return res
}