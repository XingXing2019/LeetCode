/**
 * @param {number[]} prices
 * @return {number}
 */
var maxProfit = function (prices) {
    var dp = new Array(prices.length);
    for (let i = 0; i < dp.length; i++)
        dp[i] = [0, 0];
    dp[0][0] = -prices[0];
    for (let i = 1; i < dp.length; i++) {
        dp[i][0] = Math.max(dp[i - 1][0], dp[i - 1][1] - prices[i]);
        dp[i][1] = Math.max(dp[i - 1][1], dp[i - 1][0] + prices[i]);
    }
    return dp[dp.length - 1][1];
};