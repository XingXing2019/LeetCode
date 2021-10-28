/**
 * @param {string} s
 * @return {boolean}
 */
 var isPalindrome = function(s) {
    let li = 0, hi = s.length - 1;
    while (li < hi) {
        if (!s[li].match(/[a-z]|[0-9]/i))
            li++;
        else if (!s[hi].match(/[a-z]|[0-9]/i))
            hi--;
        else if (s[li++].toLowerCase() != s[hi--].toLowerCase())
            return false;
    }
    return true;
};