/**
 * @param {number[]} nums
 * @return {number[][]}
 */
var permute = function (nums) {
    var dfs = function (nums, set, path, res) {
        if (path.length == nums.length){
            res.push(path.slice())
            return;
        }
        for (let i = 0; i < nums.length; i++) {
            if (set.has(nums[i])) continue;
            set.add(nums[i]);
            path.push(nums[i]);
            dfs(nums, set, path, res);
            path.pop();
            set.delete(nums[i]);
        }
    }
    var res = [];
    dfs(nums, new Set(), [], res);
    return res;
};