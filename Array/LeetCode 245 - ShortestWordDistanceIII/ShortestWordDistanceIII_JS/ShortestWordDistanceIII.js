/**
 * @param {string[]} wordsDict
 * @param {string} word1
 * @param {string} word2
 * @return {number}
 */
var shortestWordDistance = function(wordsDict, word1, word2) {
    var p1 = -1, p2 = -1, res = wordsDict.length
    for (let i = 0; i < wordsDict.length; i++) {
        if (wordsDict[i] == word1) {
            p1 = i
            if (p2 != -1 && p1 != p2) {
                res = Math.min(res, p1 - p2)
            }                
        }            
        if (wordsDict[i] == word2) {
            p2 = i
            if (p1 != -1 && p1 != p2) {
                res = Math.min(res, p2 - p1)
            }                
        }
    }
    return res
}