/**
 * @param {number[]} nums
 * @param {number} goal
 * @return {number}
 */
var numSubarraysWithSum = function (nums, goal) {
    var getSmaller = function (target) {
        var li = 0, hi = 0, sum = 0, res = 0
        while (hi < nums.length) {
            sum += nums[hi++]
            while (li < hi && sum > target)
                sum -= nums[li++]
            res += hi - li + 1
        }
        return res
    }
    return getSmaller(goal) - getSmaller(goal - 1)
}
