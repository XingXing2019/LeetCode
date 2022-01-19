/**
 * @param {number[]} nums
 * @param {number} k
 * @return {boolean}
 */
var containsNearbyDuplicate = function (nums, k) {
    var map = {}
    for (let i = 0; i < nums.length; i++) {
        if (i - map[nums[i]] <= k)
            return true
        map[nums[i]] = i
    }
    return false
}
