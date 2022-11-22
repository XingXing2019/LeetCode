/**
 * @param {number} n
 * @return {number}
 */
var numSquares = function(n) {
    var dp = new Array(n + 1).fill(Number.MAX_VALUE)
    for (let i = 0; i * i <= n; i++)
        dp[i * i] = 1
    for (let i = 0; i <= n; i++) {
        if (dp[i] == 1) continue
        var min = Number.MAX_VALUE
        for (let j = 0; j < i; j++)
            min = Math.min(min, dp[j] + dp[i - j])
        dp[i] = min
    }
    return dp[n]
}