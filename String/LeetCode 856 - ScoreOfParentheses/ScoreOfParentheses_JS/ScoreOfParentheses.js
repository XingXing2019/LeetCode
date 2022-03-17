/**
 * @param {string} s
 * @return {number}
 */
var scoreOfParentheses = function (s) {
    var pow = 1, res = 0
    for (let i = 0; i < s.length; i++) {
        if (s[i] == '(')
            pow *= 2
        else {
            if (s[i - 1] == '(')
                res += pow / 2
            pow /= 2
        }        
    }
    return res
}
