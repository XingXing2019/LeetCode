/**
 * @param {string} s
 * @return {string}
 */
var longestPalindrome = function (s) {
    var res = ''
    for (let i = 0; i < s.length; i++) {
        var s1 = getPalindromic(s, i, i)
        var s2 = getPalindromic(s, i, i + 1)
        if (s1.length > res.length)
            res = s1
        if (s2.length > res.length)
            res = s2
    }
    return res
};

var getPalindromic = function(s, center1, center2) {
    if (center2 >= s.length || s[center1] != s[center2])
        return ''
    var k = 1
    while (center1 - k >= 0 && center2 + k < s.length && s[center1 - k] == s[center2 + k])
        k++
    return s.substring(center1 - k + 1, center2 + k)
}