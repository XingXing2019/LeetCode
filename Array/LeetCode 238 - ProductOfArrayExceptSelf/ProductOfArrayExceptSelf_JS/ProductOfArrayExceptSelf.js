/**
 * @param {number[]} nums
 * @return {number[]}
 */
var productExceptSelf = function (nums) {
    var res = [];
    var left = 1, right = 1;
    for (let i = 0; i < nums.length; i++) {
        res.push(left);
        left *= nums[i];
    }
    for (let i = nums.length - 1; i >= 0; i--) {
        res[i] *= right;
        right *= nums[i];
    }
    return res;
};