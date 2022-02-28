/**
 * @param {number[]} nums
 * @return {string[]}
 */
var summaryRanges = function (nums) {
    nums.push(-1)
    var res = [], start = nums[0]
    for (let i = 1; i < nums.length; i++) {
        if (nums[i] == nums[i - 1] + 1) continue         
        res.push(start == nums[i - 1] ? `${start}` : `${start}->${nums[i - 1]}`)
        start = nums[i]
    }
    return res
}
