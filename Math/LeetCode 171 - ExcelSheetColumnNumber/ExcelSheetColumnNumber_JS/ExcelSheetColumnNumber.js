/**
 * @param {string} columnTitle
 * @return {number}
 */
var titleToNumber = function (columnTitle) {
    var res = 0, pow = 1
    for (let i = columnTitle.length - 1; i >= 0; i--) {
        res += (columnTitle[i].charCodeAt(0) - 'A'.charCodeAt(0) + 1) * pow
        pow *= 26
    }
    return res
}
