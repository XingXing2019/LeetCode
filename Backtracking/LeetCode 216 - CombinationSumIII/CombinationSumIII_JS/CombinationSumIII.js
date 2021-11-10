/**
 * @param {number} k
 * @param {number} n
 * @return {number[][]}
 */
var combinationSum3 = function (k, n) {
    var dfs = function (k, n, start, nums, res) {
        if (k < 0 || n < 0) return;
        if (k ===  0 && n === 0){
            res.push(nums.slice())
        }
        for (let i = start; i <= 9; i++) {
            nums.push(i);
            dfs(k - 1, n - i, i + 1, nums, res);
            nums.pop();
        }
    }
    var res = [];
    dfs(k, n, 1, [], res);
    return res;
};