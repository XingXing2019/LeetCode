/**
 * @param {number} n
 * @return {boolean}
 */
var isUgly = function(n) {
    if (n <= 0) return false
    while (n != 1) {
        if (n % 2 != 0 && n % 3 != 0 && n % 5 != 0)
            return false
        if (n % 2 == 0)
            n /= 2
        if (n % 3 == 0)
            n /= 3
        if (n % 5 == 0)
            n /= 5
    }
    return true
}