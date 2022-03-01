/**
 * @param {number} n
 * @return {number[]}
 */
var countBits = function (n) {
    if (n == 0) return [0]
    var res = [0, 1]
    for (let i = 2; i < n + 1; i++)
        res[i] = i % 2 == 0 ? res[i / 2] : res[(i - 1) / 2] + 1
    return res
}
