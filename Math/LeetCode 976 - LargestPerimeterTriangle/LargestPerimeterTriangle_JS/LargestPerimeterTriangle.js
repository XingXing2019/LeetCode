/**
 * @param {number[]} nums
 * @return {number}
 */
var largestPerimeter = function(nums) {
    nums.sort((a, b) => a - b)
    var res = 0
    for (let i = 0; i < nums.length; i++) {
        var li = i + 1, hi = nums.length - 1
        while (li < hi) {
            if (nums[i] + nums[li] > nums[hi]) {
                res = Math.max(res, nums[i] + nums[li] + nums[hi])
                li++
            } else
                hi--
        }        
    }
    return res
};

var largestPerimeter = function(nums) {
    nums.sort((a, b) => a - b)
    for (let i = nums.length - 1; i >= 2; i--) {
        if (nums[i] < nums[i - 1] + nums[i - 2])
            return nums[i] + nums[i - 1] + nums[i - 2]
    }
    return 0
};