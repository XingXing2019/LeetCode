/**
 * @param {number[]} nums
 * @return {number}
 */
var zeroFilledSubarray = function(nums) {
    var count = 0, res = 0
    for (let i = 0; i < nums.length; i++) {
        res += nums[i] == 0 ? 0 : (1 + count) * count / 2
        count = nums[i] == 0 ? count + 1 : 0
    }    
    return res + (1 + count) * count / 2
};