/**
 * @param {number[]} code
 * @param {number} k
 * @return {number[]}
 */
var decrypt = function(code, k) {
    var prefix = [...code, ...code]
    var suffix = [...code, ...code]
    var res = []
    var n = code.length
    for (let i = 1; i < 2 * n; i++) {
        prefix[i] += prefix[i - 1]
        suffix[2 * n - i - 1] += suffix[2 * n - i]
    }
    for (let i = 0; i < n; i++)
        res[i] = k >= 0 ? prefix[i + k] - prefix[i] : suffix[n + k + i] - suffix[n + i]
    return res
}