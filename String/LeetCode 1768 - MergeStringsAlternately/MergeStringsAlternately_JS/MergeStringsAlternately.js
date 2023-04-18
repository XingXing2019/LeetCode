/**
 * @param {string} word1
 * @param {string} word2
 * @return {string}
 */
var mergeAlternately = function(word1, word2) {
    var res = ''
    var p1 = 0, p2 = 0
    while (p1 < word1.length && p2 < word2.length)
        res += `${word1[p1++]}${word2[p2++]}`
    while (p1 < word1.length)
        res += word1[p1++]
    while (p2 < word2.length)
        res += word2[p2++]
    return res
}