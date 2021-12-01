/**
 * @param {number[]} nums
 * @return {number}
 */
var rob = function (nums) {
    if (nums.length == 1) return nums[0];
    if (nums.length == 2) return Math.max(nums[0], nums[1]);
    var one = nums[0], two = Math.max(nums[0], nums[1]);   
    for (let i = 2; i < nums.length; i++) {
        temp = Math.max(two, one + nums[i]);
        one = two;
        two = temp;
    }
    return two;
};