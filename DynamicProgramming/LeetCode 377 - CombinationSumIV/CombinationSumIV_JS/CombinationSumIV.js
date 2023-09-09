/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
var combinationSum4 = function(nums, target) {
    var dp = new Array(target + 1).fill(0)
    dp[0] = 1
    for (let i = 1; i < dp.length; i++) {
        for (const num of nums) {
            if (i - num < 0) continue
            dp[i] += dp[i - num]
        }
    }
    return dp[target]
}