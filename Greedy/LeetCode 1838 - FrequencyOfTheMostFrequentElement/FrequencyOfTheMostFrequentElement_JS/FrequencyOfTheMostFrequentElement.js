/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var maxFrequency = function (nums, k) {
    nums.sort((a, b) => a - b)
    var li = 0, hi = 0, sum = 0, res = 0
    while (hi < nums.length) {
        sum += nums[hi]
        while (sum + k < nums[hi] * (hi - li + 1))
            sum -= nums[li++]
        res = Math.max(res, hi - li + 1)
        hi++
    }
    return res
}
