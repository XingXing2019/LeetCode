/**
 * @param {number[]} costs
 * @param {number} coins
 * @return {number}
 */
var maxIceCream = function(costs, coins) {
    costs.sort((a, b) => a - b)
    var index = 0
    while (index < costs.length && coins >= costs[index])
        coins -= costs[index++]
    return index
}