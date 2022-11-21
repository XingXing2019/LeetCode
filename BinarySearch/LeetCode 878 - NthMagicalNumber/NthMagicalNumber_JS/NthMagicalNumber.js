/**
 * @param {number} n
 * @param {number} a
 * @param {number} b
 * @return {number}
 */
var nthMagicalNumber = function(n, a, b) {
    var lcm = a * b / gcd(a, b)
    var li = 0, hi = Math.pow(2, 64) - 1, mod = 1_000_000_000 + 7
    while (li < hi) {
        var mid = li + Math.floor((hi - li) / 2)
        var count = Math.floor(mid / a) + Math.floor(mid / b) - Math.floor(mid / lcm)
        if (count >= n)
            hi = mid
        else
            li = mid + 1
    }
    return li % mod
}

var gcd = function (x, y) {
    return y == 0 ? x : gcd(y, x % y)
}