/**
 * @param {number} n
 * @return {boolean}
 */
var isHappy = function (n) {
    var set = new Set()
    while (!set.has(n)) {
        set.add(n)
        var temp = 0
        while (n != 0) {
            temp += (n % 10) * (n % 10)
            n = parseInt(n / 10)
        }
        if (temp === 1) return true
        n = temp
    }
    return false
}
