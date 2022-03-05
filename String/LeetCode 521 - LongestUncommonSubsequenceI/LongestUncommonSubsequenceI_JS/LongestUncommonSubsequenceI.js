/**
 * @param {string} a
 * @param {string} b
 * @return {number}
 */
var findLUSlength = function (a, b) {
    return a === b ? -1 : Math.max(a.length, b.length)
}
