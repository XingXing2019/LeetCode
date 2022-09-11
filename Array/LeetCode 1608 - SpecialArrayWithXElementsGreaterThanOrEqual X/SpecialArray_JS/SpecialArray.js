/**
 * @param {number[]} nums
 * @return {number}
 */
var specialArray = function(nums) {
    nums.sort((a, b) => a- b)
    var li = 0, hi = nums[nums.length - 1]
    var binarySearch = function (nums, num) {
        var li = 0, hi = nums.length - 1
        while (li <= hi) {
            var mid = li + ~~((hi - li) / 2)
            if (nums[mid] >= num)
                hi = mid - 1
            else
                li = mid + 1
        }
        return nums.length - li
    }
    while (li <= hi) {
        var mid = li + ~~((hi - li) / 2)
        var count = binarySearch(nums, mid)
        if (count == mid)
            return mid
        if (count > mid) 
            li = mid + 1
        else
            hi = mid - 1
    }
    return hi == binarySearch(nums, hi) ? hi : -1
}