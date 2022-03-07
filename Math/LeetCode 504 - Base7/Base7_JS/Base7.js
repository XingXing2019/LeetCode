/**
 * @param {number} num
 * @return {string}
 */
var convertToBase7 = function (num) {
    if (num == 0) return '0'
    var res = ''
    var isNeg = num < 0
    num = Math.abs(num)
    while (num != 0) {
        res = num % 7 + res
        num = ~~(num / 7)
    }
    return isNeg ? `-${res}` : res
}
