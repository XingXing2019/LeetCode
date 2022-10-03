/**
 * @param {string} s
 * @return {number}
 */
var minAddToMakeValid = function(s) {
    var stack = []
    for (let i = 0; i < s.length; i++) {
        if (s[i] == '(') {
            stack.push('(')
        } else {
            if (stack.length == 0 || stack[stack.length - 1] == ')')
                stack.push(')')
            else
                stack.pop()
        }
    }
    return stack.length
}