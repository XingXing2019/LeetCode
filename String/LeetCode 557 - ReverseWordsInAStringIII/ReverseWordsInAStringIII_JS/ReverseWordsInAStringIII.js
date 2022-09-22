/**
 * @param {string} s
 * @return {string}
 */
var reverseWords = function (s) {
    var words = s.split(' ')
    var res = ''
    var reverse = function (word) {
        var res = ''
        for (let i = word.length - 1; i >= 0; i--) 
            res += word[i]
        return res
    }
    for (let i = 0; i < words.length; i++) {
        res += reverse(words[i])
        if (i != words.length - 1)
            res += ' '        
    }
    return res
}