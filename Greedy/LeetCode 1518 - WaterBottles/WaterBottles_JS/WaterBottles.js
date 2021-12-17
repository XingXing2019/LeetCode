/**
 * @param {number} numBottles
 * @param {number} numExchange
 * @return {number}
 */
var numWaterBottles = function (numBottles, numExchange) {
    var res = numBottles;
    while (numBottles >= numExchange) {
        res += ~~(numBottles / numExchange);
        numBottles = ~~(numBottles / numExchange) + numBottles % numExchange;
    }
    return res;
};