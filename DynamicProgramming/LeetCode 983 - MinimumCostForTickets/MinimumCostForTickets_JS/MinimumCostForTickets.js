/**
 * @param {number[]} days
 * @param {number[]} costs
 * @return {number}
 */
var mincostTickets = function(days, costs) {
    var dp = new Array(days[days.length - 1] + 1).fill(0)
    var set = new Set(days)
    for (let i = 1; i < dp.length; i++) {
        if (!set.has(i))
            dp[i] = dp[i - 1]
        else {
            var option1 = i - 1 >= 0 ? dp[i - 1] + costs[0] : costs[0]
            var option2 = i - 7 >= 0 ? dp[i - 7] + costs[1] : costs[1]
            var option3 = i - 30 >= 0 ? dp[i - 30] + costs[2] : costs[2]
            dp[i] = Math.min(option1, option2, option3)
        }        
    }
    return dp[dp.length - 1]
};