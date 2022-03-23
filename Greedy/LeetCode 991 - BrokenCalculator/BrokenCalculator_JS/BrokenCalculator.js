/**
 * @param {number} startValue
 * @param {number} target
 * @return {number}
 */
var brokenCalc = function (startValue, target) {
    var res = 0;
    while (target > startValue) {
        if (target % 2 != 0)
            target++;
        else
            target /= 2
        res++
    }
    return startValue > target ? res + startValue - target : res
}
