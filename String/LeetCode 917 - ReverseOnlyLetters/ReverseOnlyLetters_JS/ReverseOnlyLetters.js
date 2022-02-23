/**
 * @param {string} s
 * @return {string}
 */
var reverseOnlyLetters = function (s) {
    res = []
    for (let i = 0; i < s.length; i++) 
        res[i] = s[i]
    var li = 0, hi = s.length - 1
    while (li < hi) {
        if (!res[li].match(/[a-z]/i))
            li++
        else if (!res[hi].match(/[a-z]/i))
            hi--
        else {
            var temp = res[li]
            res[li++] = res[hi]
            res[hi--] = temp
        }
    }
    return res.join('')
}
