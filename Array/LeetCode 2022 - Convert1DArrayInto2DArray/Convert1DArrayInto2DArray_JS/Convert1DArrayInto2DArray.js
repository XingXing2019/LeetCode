/**
 * @param {number[]} original
 * @param {number} m
 * @param {number} n
 * @return {number[][]}
 */
var construct2DArray = function (original, m, n) {
    if (m * n !== original.length)
        return []
    var res = []
    for (let i = 0; i < m; i++)
        res[i] = []
    var r = 0, c = 0
    for (let i = 0; i < original.length; i++) {
        res[r][c] = original[i]
        c++
        if (c === n) {
            r++
            c = 0
        }
    }
    return res
}
