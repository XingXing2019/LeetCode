/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
var search = function(nums, target) {
    var li = 0, hi = nums.length - 1
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        if (nums[mid] == target)
            return mid
        if (nums[mid] < target)
            li = mid + 1
        else
            hi = mid - 1
    }
    return -1
}