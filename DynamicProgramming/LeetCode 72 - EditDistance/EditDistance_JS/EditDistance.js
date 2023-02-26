/**
 * @param {string} word1
 * @param {string} word2
 * @return {number}
 */
var minDistance = function (word1, word2) {
    if (word1.length == 0 || word2.length == 0)
        return Math.max(word1.length, word2.length)
    var dp = new Array(word1.length)
    for (let i = 0; i < dp.length; i++)
        dp[i] = new Array(word2.length).fill(0)
    dp[0][0] = word1[0] == word2[0] ? 0 : 1
    for (let i = 1; i < word1.length; i++)
        dp[i][0] = word1[i] == word2[0] ? i : dp[i - 1][0] + 1
    for (let i = 1; i < word2.length; i++)
        dp[0][i] = word1[0] == word2[i] ? i : dp[0][i - 1] + 1
    for (let i = 1; i < word1.length; i++) {
        for (let j = 1; j < word2.length; j++) {
            if (word1[i] == word2[j])
                dp[i][j] = dp[i - 1][j - 1]
            else
                dp[i][j] = Math.min(dp[i - 1][j - 1], Math.min(dp[i - 1][j], dp[i][j - 1])) + 1
        }        
    }
    return dp[word1.length - 1][word2.length - 1]
}