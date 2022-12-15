/**
 * @param {string} text1
 * @param {string} text2
 * @return {number}
 */
var longestCommonSubsequence = function(text1, text2) {
    var dp = new Array(text1.length)
    for (let i = 0; i < text1.length; i++)
        dp[i] = new Array(text2.length).fill(0)
    dp[0][0] = text1.charAt(0) == text2.charAt(0)
    for (let i = 1; i < text1.length; i++)
        dp[i][0] = text1.charAt(i) == text2.charAt(0) ? 1 : dp[i - 1][0]
    for (let j = 1; j < text2.length; j++)
        dp[0][j] = text1.charAt(0) == text2.charAt(j) ? 1 : dp[0][j - 1]
    for (let i = 1; i < text1.length; i++) {
        for (let j = 1; j < text2.length; j++) {
            dp[i][j] = text1.charAt(i) == text2.charAt(j) ? dp[i - 1][j - 1] + 1 : Math.max(dp[i - 1][j], dp[i][j - 1])
        }        
    }
    return dp[text1.length - 1][text2.length - 1]
}