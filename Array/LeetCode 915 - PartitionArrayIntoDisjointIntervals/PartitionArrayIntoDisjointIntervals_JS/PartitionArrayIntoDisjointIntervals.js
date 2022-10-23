/**
 * @param {number[]} nums
 * @return {number}
 */
var partitionDisjoint = function (nums) {
    var leftMax = new Array(nums.length).fill(0)
    var rightMin = new Array(nums.length).fill(0)
    var max = nums[0], min = nums[nums.length - 1]
    for (let i = 0; i < nums.length; i++) {
        leftMax[i] = max
        max = Math.max(max, nums[i])
        rightMin[nums.length - i - 1] = min
        min = Math.min(min, nums[[nums.length - i - 1]])
    }
    for (let i = 0; i < nums.length; i++) {
        if (leftMax[i] > rightMin[i]) continue
        return i + 1
    }
    return -1
}