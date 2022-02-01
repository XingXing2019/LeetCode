/**
 * @param {number[]} prices
 * @return {number}
 */
var maxProfit = function (prices) {
    var min = prices[0], res = 0
    for (let i = 0; i < prices.length; i++) {
        min = Math.min(min, prices[i])
        res = Math.max(res, prices[i] - min)        
    }
    return res
}
