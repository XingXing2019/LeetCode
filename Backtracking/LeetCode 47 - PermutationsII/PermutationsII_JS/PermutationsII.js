/**
 * @param {number[]} nums
 * @return {number[][]}
 */
var permuteUnique = function (nums) {
    var dfs = function (nums, set, path, res) {
        if (path.length == nums.length)
            res.push(path.slice());
        for (let i = 0; i < nums.length; i++) {
            if (set.has(i)) continue;
            if (i > 0 && nums[i] == nums[i - 1] && !set.has(i - 1)) continue;
            set.add(i);
            path.push(nums[i]);
            dfs(nums, set, path, res);
            path.pop();
            set.delete(i);
        }
    }
    nums.sort((a, b) => {return a - b});
    var res = [];
    dfs(nums, new Set(), [], res);
    return res;
};