/**
 * @param {number[]} nums
 * @return {number}
 */
var maxProduct = function (nums) {
    var min = [], max = [];
    min[0] = nums[0];
    max[0] = nums[0];
    var res = nums[0];
    for (let i = 1; i < nums.length; i++) {
        max[i] = Math.max(nums[i], nums[i] * min[i - 1], nums[i] * max[i - 1]);
        min[i] = Math.min(nums[i], nums[i] * min[i - 1], nums[i] * max[i - 1]);
        res = Math.max(res, max[i]);        
    }
    return res;
};