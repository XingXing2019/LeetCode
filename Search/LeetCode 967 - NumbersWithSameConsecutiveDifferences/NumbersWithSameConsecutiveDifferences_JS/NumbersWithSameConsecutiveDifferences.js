/**
 * @param {number} n
 * @param {number} k
 * @return {number[]}
 */
var numsSameConsecDiff = function (n, k) {
    var res = []
    var dfs = function (num, lastDigit, len) {
        if (lastDigit >= 10 || lastDigit < 0)
            return
        if (len == n) {
            res.push(num)
            return
        }
        dfs(num * 10 + lastDigit + k, lastDigit + k, len + 1)
        if (k == 0) return
        dfs(num * 10 + lastDigit - k, lastDigit - k, len + 1)
    }
    for (let i = 1; i < 10; i++)
        dfs(i, i, 1)
    return res
}
