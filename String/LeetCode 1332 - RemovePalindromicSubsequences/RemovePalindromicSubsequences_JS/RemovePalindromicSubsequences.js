/**
 * @param {string} s
 * @return {number}
 */
var removePalindromeSub = function (s) {
    var isPalindrome = function (s) {
        var li = 0, hi = s.length - 1
        while (li < hi) {
            if (s[li++] != s[hi--])
                return false
        }
        return true
    }
    if (s == '') return 0;
    return isPalindrome(s) ? 1 : 2
}
