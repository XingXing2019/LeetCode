/**
 * @param {number[]} nums
 * @return {void} Do not return anything, modify nums in-place instead.
 */
var wiggleSort = function(nums) {
    var copy = nums.slice()
    copy.sort((a, b) => a - b)
    var li = 0, hi = copy.length - 1
    for (let i = 0; i < nums.length; i++) {
        if (i % 2 == 0)
            nums[i] = copy[li++]
        else
            nums[i] = copy[hi--]
    }
}