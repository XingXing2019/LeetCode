/**
 * @param {number[][]} workers
 * @param {number[][]} bikes
 * @return {number}
 */
var assignBikes = function(workers, bikes) {
    var dp = new Array((1 << bikes.length) - 1).fill(-1)
    return dfs(workers, bikes, 0, dp, 0)
}

var dfs = function (worker, bikes, pos, dp, state) {
    if (pos == worker.length) return 0
    if (state == (1 << bikes.length) - 1) return 0
    if (dp[state] != -1) return dp[state]
    var res = Number.MAX_VALUE
    for (let i = 0; i < bikes.length; i++) {
        if ((state >> i) & 1 != 0) continue
        var dis = Math.abs(bikes[i][0] - worker[pos][0]) + Math.abs(bikes[i][1] - worker[pos][1])
        res = Math.min(res, dis + dfs(worker, bikes, pos + 1, dp, state | (1 << i)))        
    }
    return dp[state] = res
}