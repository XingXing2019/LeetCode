/**
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstringTwoDistinct = function(s) {
    var letters = new Map()
    var li = 0, hi = 0, res = 0
    while (hi < s.length) {
        if (!letters.has(s[hi]))
            letters.set(s[hi], 0)
        letters.set(s[hi], letters.get(s[hi]) + 1)
        while (letters.size > 2) { 
            letters.set(s[li], letters.get(s[li]) - 1)
            if (letters.get(s[li]) == 0)
                letters.delete(s[li])
            li++
        }
        res = Math.max(res, hi - li + 1)
        hi++
    }
    return res
}