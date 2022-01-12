/**
 * @param {number[]} nums
 * @return {boolean}
 */
var increasingTriplet = function (nums) {
    var min = Number.MAX_VALUE, secMin = Number.MAX_VALUE
    for (const num of nums) {
        if (num > secMin) return true
        if (num < min) {
            min = num
        } else if (num < secMin && num > min) {
            secMin = num
        }
    }
    return false
}
