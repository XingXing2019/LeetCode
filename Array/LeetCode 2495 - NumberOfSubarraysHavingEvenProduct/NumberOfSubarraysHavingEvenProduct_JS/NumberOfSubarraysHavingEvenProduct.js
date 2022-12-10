/**
 * @param {number[]} nums
 * @return {number}
 */
var evenProduct = function(nums) {
    var res = 0, lastEven = -1
    for (let i = 0; i < nums.length; i++) {
        res += nums[i] % 2 == 0 ? i + 1 : lastEven + 1
        lastEven = nums[i] % 2 == 0 ? i : lastEven
    }
    return res
}