/**
 * @param {string} s
 * @return {string}
 */
var longestNiceSubstring = function (s) {
    var res = ''
    var isNice = function (lower, upper) {
        for (let i = 0; i < 26; i++) {
            if ((lower[i] || upper[i]) && !(lower[i] * upper[i]))
            return false    
        }
        return true
    }
    for (let i = 0; i < s.length; i++) {
        var lower = [], upper = []
        for (let j = i; j < s.length; j++) {
            if (s[j].toLowerCase() == s[j]) {
                var index = s[j].charCodeAt(0) - 'a'.charCodeAt(0)
                if (!lower[index]) lower[index] = 0
                lower[index]++
            } else {
                var index = s[j].charCodeAt(0) - 'A'.charCodeAt(0)
                if (!upper[index]) upper[index] = 0
                upper[index]++
            }
            if (j - i + 1 > res.length && isNice(lower, upper))
                res = s.substring(i, j + 1)
        }        
    }
    return res
}
