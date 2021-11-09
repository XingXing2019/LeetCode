/**
 * @param {number[]} candidates
 * @param {number} target
 * @return {number[][]}
 */
var combinationSum = function (candidates, target) {
    var dfs = function (candidates, target, start, nums, res){
        if (target < 0) return;
        if (target == 0) {            
            res.push(nums.slice());
            return;
        }
        for (let i = start; i < candidates.length; i++) {
            nums.push(candidates[i]);
            dfs(candidates, target - candidates[i], i, nums, res);
            nums.pop();            
        }
    }
    var res = [];
    dfs(candidates, target, 0, [], res);
    return res;
};