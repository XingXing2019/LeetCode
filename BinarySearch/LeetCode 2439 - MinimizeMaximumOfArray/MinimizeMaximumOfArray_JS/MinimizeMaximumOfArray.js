/**
 * @param {number[]} nums
 * @return {number}
 */
var minimizeArrayValue = function(nums) {
    var isValid = function (nums, target) {        
        for (let i = nums.length - 1; i >= 1; i--) {
            if (nums[i] <= target) continue
            nums[i - 1] += nums[i] - target
            nums[i] = target
        }
        return nums[0] <= target
    }    
    var li = 0, hi = 1_000_000_000
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        if (isValid(nums.slice(), mid))
            hi = mid - 1
        else
            li = mid + 1
    }
    return li
};