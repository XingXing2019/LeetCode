/**
 * @param {number[]} nums
 * @return {number[][]}
 */
var findSubsequences = function(nums) {
    var res = []
    dfs(nums, 0, [], res, new Set())
    return res
}

var dfs = function (nums, start, combo, res, visited) {   
    if (combo.length > 1) {
        var pattern = combo.join(':')
        if (visited.has(pattern)) return
        visited.add(pattern)
        res.push(combo.slice())
    }
    for (let i = start; i < nums.length; i++) {
        if (combo.length != 0 && nums[i] < combo[combo.length - 1])
            continue
        combo.push(nums[i])
        dfs(nums, i + 1, combo, res, visited)
        combo.pop()
    }
}