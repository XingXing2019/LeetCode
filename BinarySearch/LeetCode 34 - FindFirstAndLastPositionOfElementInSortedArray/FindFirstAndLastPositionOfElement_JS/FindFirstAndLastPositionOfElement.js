/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number[]}
 */
var searchRange = function(nums, target) {
    return [findFirst(nums, target), findLast(nums, target)]
}

var findFirst = function (nums, target) {
    var li = 0, hi = nums.length - 1
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        if (nums[mid] >= target)
            hi = mid - 1
        else
            li = mid + 1
    }
    return li >= 0 && nums[li] == target ? li : -1
}

var findLast = function (nums, target) {
    var li = 0, hi = nums.length - 1
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        if (nums[mid] <= target)
            li = mid + 1
        else
            hi = mid - 1
    }
    return hi < nums.length && nums[hi] == target ? hi : -1
}