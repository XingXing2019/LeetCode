/**
 * @param {number[]} scores
 * @param {number[]} ages
 * @return {number}
 */
var bestTeamScore = function(scores, ages) {
    var record = []
    for (let i = 0; i < scores.length; i++)
        record.push([ages[i], scores[i]])
    record.sort((a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0])
    var dp = new Array(scores.length)
    var res = 0
    for (let i = 0; i < dp.length; i++) {
        dp[i] = record[i][1]
        for (let j = 0; j < i; j++) {
            if (record[j][0] == record[i][0] || record[j][1] <= record[i][1])
                dp[i] = Math.max(dp[i], dp[j] + record[i][1])
        }
        res = Math.max(res, dp[i])
    }
    return res
}