/**
 * @param {string} s
 * @return {string}
 */
var makeGood = function(s) {
    var stack = []
    var diff = 'a'.charCodeAt(0) - 'A'.charCodeAt(0)
    for (let i = 0; i < s.length; i++) {
        if (stack.length == 0 || Math.abs(s.charCodeAt(i) - stack[stack.length - 1].charCodeAt(0)) != diff)
            stack.push(s[i])
        else
            stack.pop()
    }
    return stack.join('')
}