/**
 * @param {number[]} nums
 * @return {number}
 */
var singleNonDuplicate = function (nums) {
    var li = 1, hi = nums.length - 1;
    while (li <= hi) {
        var mid = ~~((li + hi) / 2);
        if (mid % 2 == 0) {
            if (nums[mid] == nums[mid - 1])
                hi = mid - 1;
            else
                li = mid + 1;
        } else {
            if (nums[mid] == nums[mid - 1])
                li = mid + 1;
            else
                hi = mid - 1;
        }
    }
    return nums[hi];
};