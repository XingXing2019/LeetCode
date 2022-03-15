/**
 * @param {number[]} nums
 * @return {number}
 */
var countMaxOrSubsets = function (nums) {
    var map = {}, max = 0
    var dfs = function (nums, or, start) {
        if (map[or] == undefined)
            map[or] = 0
        map[or]++
        max = Math.max(max, map[or])
        for (let i = start; i < nums.length; i++) {
            dfs(nums, or | nums[i], i + 1)            
        }
    }
    dfs(nums, 0, 0)
    return max
}
