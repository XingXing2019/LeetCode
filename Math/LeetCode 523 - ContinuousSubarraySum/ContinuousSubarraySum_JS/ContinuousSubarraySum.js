/**
 * @param {number[]} nums
 * @param {number} k
 * @return {boolean}
 */
var checkSubarraySum = function(nums, k) {
    for (let i = 1; i < nums.length; i++) 
        nums[i] += nums[i - 1]
    var modMap = new Map()
    var map = new Map()
    modMap.set(0, -1)
    map.set(0, -1)
    for (let i = 0; i < nums.length; i++) {
        var mod = nums[i] % k
        if (!modMap.has(mod))
            modMap.set(mod, i)
        else if (i - modMap.get(mod) > 1)            
            return true
        if (!map.has(nums[i]))
            map.set(nums[i], i)
        else if (i - map.get(nums[i]) > 1)
            return true
    }
    return false
}