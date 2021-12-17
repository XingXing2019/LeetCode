/**
 * @param {character[][]} matrix
 * @return {number}
 */
var maximalSquare = function (matrix) {
    var dp = [];
    var m = matrix.length, n = matrix[0].length, max = 0;
    for (let i = 0; i < m; i++)
        dp[i] = [];
    for (let i = 0; i < m; i++){
        dp[i][0] = matrix[i][0] == '0' ? 0 : 1;
        max = Math.max(max, dp[i][0]);
    }
    for (let i = 0; i < n; i++) {
        dp[0][i] = matrix[0][i] == '0' ? 0 : 1;
        max = Math.max(max, dp[0][i]);
    }        
    for (let i = 1; i < m; i++) {
        for (let j = 1; j < n; j++) {
            if (matrix[i][j] === '0') 
                dp[i][j] = 0;
            else {                
                dp[i][j] = Math.min(dp[i - 1][j], dp[i][j - 1], dp[i - 1][j - 1]) + 1
                max = Math.max(max, dp[i][j]);
            }
        }
    }
    return max * max;
};