/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var subarraysWithKDistinct = function (nums, k) {
    var countLess = function (target) {
        var map = new Map()
        var li = 0, hi = 0, res = 0
        while (hi < nums.length) {
            if (!map.has(nums[hi]))
                map.set(nums[hi], 0)
            map.set(nums[hi], map.get(nums[hi]) + 1)
            hi++
            while (li < hi && map.size > target) {
                map.set(nums[li], map.get(nums[li]) - 1)
                if (map.get(nums[li]) === 0)
                    map.delete(nums[li])
                li++
            }
            res += hi - li + 1
        }
        return res
    }
    return countLess(k) - countLess(k - 1)
}
