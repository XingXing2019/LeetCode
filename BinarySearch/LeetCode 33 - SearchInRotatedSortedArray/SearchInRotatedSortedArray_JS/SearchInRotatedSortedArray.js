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
        if (nums[li] < nums[mid]) {
            if (nums[li] <= target && target <= nums[mid])
                hi = mid - 1
            else
                li = mid + 1
        } else {
            if (nums[mid] <= target && target <= nums[hi])
                li = mid + 1
            else
                hi = mid - 1
        }
    }
    return -1
}