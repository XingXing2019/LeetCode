/**
 * @param {number[]} num
 * @param {number} k
 * @return {number[]}
 */
var addToArrayForm = function(num, k) {
    var res = []
    var index = num.length - 1, cur = 0, car = 0
    while (index >= 0 && k != 0) {
        cur = (num[index] + k % 10 + car) % 10
        car = ~~((num[index] + k % 10 + car) / 10)
        res.push(cur)
        index--
        k = ~~(k / 10)
    }
    while (index >= 0) {
        cur = (num[index] + car) % 10
        car = ~~((num[index] + car) / 10)
        res.push(cur)
        index--
    }
    while (k != 0) {
        cur = (k % 10 + car) % 10
        car = ~~((k % 10 + car) / 10)
        res.push(cur)
        k = ~~(k / 10)
    }
    if (car != 0) res.push(car)
    return res.reverse()
}