/**
 * @param {number} n
 * @return {number}
 */
var numberOfMatches = function (n) {
    var res = 0
    while (n != 1) {
        res += parseInt(n / 2)
        n = Math.ceil(n / 2)
    }
    return res
}
