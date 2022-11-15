/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var twoSumLessThanK = function(nums, k) {
    nums.sort((a, b) => a - b)
    var res = -1, li = 0, hi = nums.length - 1
    while (li < hi) {
        if (nums[li] + nums[hi] >= k) 
            hi--
        else
            res = Math.max(res, nums[li++] + nums[hi])
    }
    return res
}