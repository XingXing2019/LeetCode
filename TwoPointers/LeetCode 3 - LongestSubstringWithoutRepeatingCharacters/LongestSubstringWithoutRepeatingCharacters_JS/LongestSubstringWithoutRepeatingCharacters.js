/**
 * @param {string} s
 * @return {number}
 */
var lengthOfLongestSubstring = function (s) {
    var map = [];
    for (let i = 0; i < 128; i++)
        map[i] = 0;
    var li = 0, hi = 0, res = 0;
    while (hi < s.length) {
        map[s[hi].charCodeAt()]++;
        while (li < hi && map[s[hi].charCodeAt()] > 1)
            map[s[li++].charCodeAt()]--;
        res = Math.max(res, hi - li + 1);
        hi++;
    }
    return res;
}
