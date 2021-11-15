/**
 * @param {number[]} nums
 * @return {number[]}
 */
var largestDivisibleSubset = function (nums) {
    nums.sort((a, b) => {return a - b});
    var dp = [], res = [nums[0]];
    dp.push([nums[0]]);
    var maxLen = 1;
    for (let i = 1; i < nums.length; i++) {
        var len = 1;
        var temp = [];
        for (let j = i - 1; j >= 0; j--) {
            if (nums[i] % nums[j] == 0 && dp[j].length + 1 > len){
                temp = dp[j];
                len = dp[j].length + 1;
            }        
        }
        dp[i] = temp.slice();
        dp[i].push(nums[i]);
        if (dp[i].length > maxLen){
            res = dp[i];
            maxLen = dp[i].length;
        }
    }
    return res;
};