/**
 * @param {number[]} nums
 * @return {number}
 */
var deleteAndEarn = function (nums) {
    var record = [], dp = []
    var max = Math.max(...nums)
    for (let i = 0; i <= max; i++) {
        record[i] = 0
        dp[i] = 0
    }
    nums.forEach(x => { record[x] += x })
    var max = record[1]
    dp[1] = record[1]
    for (let i = 2; i < dp.length; i++) { 
        dp[i] = Math.max(dp[i - 2] + record[i], dp[i - 1])        
        max = Math.max(max, dp[i])
    }
    return max
}
