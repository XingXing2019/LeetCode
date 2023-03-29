/**
 * @param {number[]} satisfaction
 * @return {number}
 */
var maxSatisfaction = function(satisfaction) {
    satisfaction.sort((a, b) => a - b)
    var res = 0, temp = 0
    for (let i = satisfaction.length - 1; i >= 0 && temp + satisfaction[i] > 0; i--) {
        temp += satisfaction[i]
        res += temp
    }
    return res
}