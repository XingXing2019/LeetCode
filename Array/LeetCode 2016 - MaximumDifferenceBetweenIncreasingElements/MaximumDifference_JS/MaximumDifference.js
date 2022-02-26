/**
 * @param {number[]} nums
 * @return {number}
 */
var maximumDifference = function (nums) {
    var min = nums[0], res = -Number.MAX_VALUE
    for (let i = 1; i < nums.length; i++) {
        if (nums[i] > min)
            res = Math.max(res, nums[i] - min)
        min = Math.min(min, nums[i])        
    }
    return res == -Number.MAX_VALUE ? -1 : res
}
