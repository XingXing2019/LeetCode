/**
 * @param {number[]} nums
 * @return {number}
 */
var minStartValue = function (nums) {
    var min = nums[0];
    for (let i = 1; i < nums.length; i++) {
        nums[i] += nums[i - 1];
        min = Math.min(min, nums[i]);
    }
    return Math.max(1, 1 - min);
};