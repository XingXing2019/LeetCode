/**
 * @param {number} n
 * @return {number}
 */
var concatenatedBinary = function(n) {
    var pow = 1, res = 0, mod = 1_000_000_000 + 7
    for (let i = 1; i <= n; i++) {
        if (i == pow)
            pow <<= 1
        res = (res * pow + i) % mod
    }
    return res
}