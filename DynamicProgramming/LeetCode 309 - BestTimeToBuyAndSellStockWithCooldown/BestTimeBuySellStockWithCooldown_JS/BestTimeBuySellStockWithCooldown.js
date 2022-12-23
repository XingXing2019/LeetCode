/**
 * @param {number[]} prices
 * @return {number}
 */
var maxProfit = function(prices) {
    var hasStock = new Array(prices.length).fill(0)   
    var noStock = new Array(prices.length).fill(0)   
    hasStock[0] = -prices[0]
    for (let i = 1; i < prices.length; i++) {
        hasStock[i] = i == 1 ? Math.max(-prices[i], hasStock[i - 1]) : Math.max(noStock[i - 2] - prices[i], hasStock[i - 1])
        noStock[i] = Math.max(noStock[i - 1], hasStock[i - 1] + prices[i])
    }
    return noStock[prices.length - 1]
}