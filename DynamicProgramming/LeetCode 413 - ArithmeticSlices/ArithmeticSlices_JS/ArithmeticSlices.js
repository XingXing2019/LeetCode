/**
 * @param {number[]} nums
 * @return {number}
 */
var numberOfArithmeticSlices = function (nums) {
    if (nums.length === 1) return 0
    var li = 0, hi = 1, diff = nums[hi] - nums[li], res = 0
    while (hi < nums.length) {
        if (nums[hi] - nums[hi - 1] !== diff) {
            if (hi - li >= 3)
                res += (1 + (hi - li - 2)) * (hi - li - 2) / 2
            li = hi - 1
            diff = nums[hi] - nums[li]
        }
        else
            hi++
    }
    if (hi - li >= 3)
        res += (1 + (hi - li - 2)) * (hi - li - 2) / 2
    return res
}
