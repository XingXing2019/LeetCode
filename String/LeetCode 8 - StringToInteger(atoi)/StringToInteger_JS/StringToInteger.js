/**
 * @param {string} s
 * @return {number}
 */
var myAtoi = function (s) {
    var int = parseInt(s)
    if (isNaN(int))
        return 0
    if (int > 2147483647) return 2147483647
    if (int < -2147483648) return -2147483648
    return int
}
