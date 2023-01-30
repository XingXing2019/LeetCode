/**
 * @param {number} n
 * @return {number}
 */
var tribonacci = function (n) {
    if (n < 3) return n == 0 ? 0 : 1
    var t0 = 0, t1 = 1, t2 = 1
    for (let i = 3; i <= n; i++) {
        var temp = t0 + t1 + t2
        t0 = t1
        t1 = t2
        t2 = temp
    }
    return t2
}