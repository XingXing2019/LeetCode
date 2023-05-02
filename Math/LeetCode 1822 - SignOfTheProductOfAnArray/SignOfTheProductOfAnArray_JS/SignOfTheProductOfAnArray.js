/**
 * @param {number[]} nums
 * @return {number}
 */
var arraySign = function(nums) {
    var neg = 0
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] == 0) return 0
        neg += nums[i] < 0 ? 1 : 0
    }
    return neg % 2 == 0 ? 1 : -1
}