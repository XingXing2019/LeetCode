/**
 * @param {string} s1
 * @param {string} s2
 * @return {boolean}
 */
var areAlmostEqual = function (s1, s2) {
    if (s1 == s2) return true
    var freq = new Array(26).fill(0)
    var a = 'a'.charCodeAt(0)
    for (let i = 0; i < s1.length; i++) 
        freq[s1.charCodeAt(i) - a]++
    for (let i = 0; i < s2.length; i++) {
        freq[s2.charCodeAt(i) - a]--
        if (freq[s2.charCodeAt(i) - a] < 0)
            return false
    }
    var count = 0
    for (let i = 0; i < s1.length; i++) {
        if (s1[i] == s2[i]) continue
        count++
    }
    return count <= 2
};