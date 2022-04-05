/**
 * @param {number} left
 * @param {number} right
 * @return {number}
 */
var countPrimeSetBits = function (left, right) {
    var primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 27, 29, 31]
    var res = 0
    for (let i = left; i <= right; i++) {
        var count = 0, temp = i
        while (temp != 0) {
            if ((temp & 1) == 1)
                count++
            temp >>= 1
        }
        if (primes.includes(count))
            res++
    }
    return res
}
