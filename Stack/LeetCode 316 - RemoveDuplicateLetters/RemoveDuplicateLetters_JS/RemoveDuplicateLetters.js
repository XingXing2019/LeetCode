/**
 * @param {string} s
 * @return {string}
 */
var removeDuplicateLetters = function (s) {
    var stack = []
    var freq = []
    for (let i = 0; i < 26; i++)
        freq[i] = 0
    for (let i = s.length - 1; i >= 0; i--) {
        var code = s[i].charCodeAt(0) - 'a'.charCodeAt(0)
        freq[code]++
    }
    for (let i = 0; i < s.length; i++) {
        freq[s[i].charCodeAt(0) - 'a'.charCodeAt(0)]--
        if (stack.some(x => x == s[i])) continue
        while (
            stack.length != 0 &&
            stack[stack.length - 1].charCodeAt(0) > s[i].charCodeAt(0) &&
            freq[stack[stack.length - 1].charCodeAt(0) - 'a'.charCodeAt(0)] > 0
        ) {
            stack.pop()
        }
        stack.push(s[i])
    }
    var res = ''
    for (let i = stack.length - 1; i >= 0; i--) 
        res = stack[i] + res
    return res    
}
