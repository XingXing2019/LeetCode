/**
 * @param {number[]} nums
 * @return {number}
 */
var findMaxConsecutiveOnes = function(nums) {
    var li = 0, hi = 0, count = 1, res = 0
    while (hi < nums.length) {
        count -= nums[hi++] ^ 1
        while (li < hi && count < 0)
            count += nums[li++] ^ 1
        res = Math.max(res, hi - li)
    }
    return Math.max(res, hi - li)
};