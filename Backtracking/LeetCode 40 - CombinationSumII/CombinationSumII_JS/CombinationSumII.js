/**
 * @param {number[]} candidates
 * @param {number} target
 * @return {number[][]}
 */
var combinationSum2 = function (candidates, target) {
    var dfs = function (candidates, target, start, nums, res) {
        if (target < 0) return;
        if (target == 0){
            res.push(nums.slice());
            return;
        }
        for (let i = start; i < candidates.length; i++) {
            if (i > start && candidates[i] == candidates[i - 1]) continue;
            nums.push(candidates[i]);
            dfs(candidates, target - candidates[i], i + 1, nums, res);
            nums.pop();
        }
    }
    candidates.sort((a, b) => {return a - b});
    var res = [];
    dfs(candidates, target, 0, [], res);
    return res;
};