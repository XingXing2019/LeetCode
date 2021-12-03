/**
 * @param {number[]} nums
 * @return {number}
 */
var maxProduct = function (nums) {
    var min = nums[0], max = nums[0], res = nums[0];
    for (let i = 1; i < nums.length; i++) {
        var tempMax = Math.max(nums[i], nums[i] * min, nums[i] * max);
        var tempMin = Math.min(nums[i], nums[i] * min, nums[i] * max);
        max = tempMax;
        min = tempMin;
        res = Math.max(res, max);        
    }
    return res;
};