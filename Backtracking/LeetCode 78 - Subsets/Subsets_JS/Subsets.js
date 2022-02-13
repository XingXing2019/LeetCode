/**
 * @param {number[]} nums
 * @return {number[][]}
 */
var subsets = function (nums) {
    var dfs = function (start, nums, res, subset) {
        res.push(subset.slice())
        for (let i = start; i < nums.length; i++) {
            subset.push(nums[i])
            dfs(i + 1, nums, res, subset)
            subset.pop()
        }
    }
    var res = []
    dfs(0, nums, res, [])
    return res
}
