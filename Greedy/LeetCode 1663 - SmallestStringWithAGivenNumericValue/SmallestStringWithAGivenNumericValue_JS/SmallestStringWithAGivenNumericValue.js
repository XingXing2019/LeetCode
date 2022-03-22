/**
 * @param {number} n
 * @param {number} k
 * @return {string}
 */
var getSmallestString = function (n, k) {
    var res = ''
    for (let i = 1; i < n; i++) {
        var letter = k <= 26 * (n - i) ? 1 : k - 26 * (n - i)
        res += String.fromCharCode(letter + 'a'.charCodeAt(0) - 1)
        k -= letter
    }
    return res + String.fromCharCode(k + 'a'.charCodeAt(0) - 1)
}
