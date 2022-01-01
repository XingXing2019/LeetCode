/**
 * @param {number[]} nums
 * @return {number}
 */
var maxCoins = function (nums) {
    var dfs = function (li, hi) {
        if (li > hi) return 0
        if (dp[li][hi]) return dp[li][hi]
        var max = 0
        for (let i = li; i <= hi; i++) {
            var coins = (li === 0 ? 1 : nums[li - 1]) * nums[i] * (hi === nums.length - 1 ? 1 : nums[hi + 1])
            var cur = dfs(li, i - 1) + coins + dfs(i + 1, hi)
            max = Math.max(max, cur)
        }
        dp[li][hi] = max
        return max
    }
    var dp = []
    for (let i = 0; i < nums.length; i++) 
        dp[i] = []
    return dfs(0, nums.length - 1)
}
