/**
 * @param {string} s
 * @return {string}
 */
var minRemoveToMakeValid = function (s) {
    var count = 0
    var res = ''
    for (let i = 0; i < s.length; i++) {
        if (s[i] == '(') {
            res += s[i]
            count++
        } else if (s[i] == ')') {
            if (count - 1 >= 0) {
                count--
                res += s[i]
            }
        } else {
            res += s[i]
        }
    }
    s = res
    res = ''
    count = 0
    for (let i = s.length - 1; i >= 0; i--) {
        if (s[i] == ')') {
            res = s[i] + res
            count++
        } else if (s[i] == '(') {
            if (count - 1 >= 0) {
                count--
                res = s[i] + res
            }
        } else {
            res = s[i] + res
        }
    }
    return res
}
