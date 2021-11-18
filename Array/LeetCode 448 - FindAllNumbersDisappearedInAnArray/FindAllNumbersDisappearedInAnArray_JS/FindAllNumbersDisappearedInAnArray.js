/**
 * @param {number[]} nums
 * @return {number[]}
 */
var findDisappearedNumbers = function (nums) {
    for (let i = 0; i < nums.length; i++) {
        var index = Math.abs(nums[i]) - 1;
        nums[index] = Math.min(nums[index], -nums[index]);        
    }
    var res = [];
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] > 0)
            res.push(i + 1);
    }
    return res;
};