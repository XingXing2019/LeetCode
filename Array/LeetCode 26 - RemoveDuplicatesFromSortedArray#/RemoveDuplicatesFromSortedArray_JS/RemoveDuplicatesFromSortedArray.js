/**
 * @param {number[]} nums
 * @return {number}
 */
var removeDuplicates = function(nums) {
    var p1 = 1, p2 = 1
    while (p2 < nums.length) {
        if (nums[p2] != nums[p2 - 1])
            nums[p1++] = nums[p2]
        p2++
    }
    return p1
}