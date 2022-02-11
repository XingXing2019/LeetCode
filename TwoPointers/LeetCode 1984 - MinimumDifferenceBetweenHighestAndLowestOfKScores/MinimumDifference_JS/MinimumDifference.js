/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var minimumDifference = function (nums, k) {
    nums.sort((a, b) => { return a - b })
    var res = nums[nums.length - 1] - nums[0]
    for (let i = 0; i <= nums.length - k; i++)
        res = Math.min(res, nums[i + k - 1] - nums[i])
    return res
}
