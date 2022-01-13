/**
 * @param {number[]} nums
 * @return {number}
 */
var dominantIndex = function (nums) {
    var max = 0, secMax = 0, index = 0
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] > max) {
            secMax = max
            max = nums[i]
            index = i
        } else if (nums[i] > secMax)
            secMax = nums[i]        
    }
    return max >= 2 * secMax ? index : -1
}
