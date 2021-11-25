/**
 * @param {number[]} nums
 * @return {number}
 */
var maxSubArray = function (nums) {
    var prev = nums[0];
    var cur = 0;
    var res = prev;
    for (let i = 1; i < nums.length; i++) {
        cur = Math.max(prev + nums[i], nums[i]);
        res = Math.max(res, cur);
        prev = cur;
    }
    return res;
};