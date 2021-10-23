/**
 * @param {string} s
 * @return {boolean}
 */
var isValid = function (s) {
    let map = {
        ')': '(',
        ']': '[',
        '}': '{'
    };
    let stack = [];
    for (let i = 0; i < s.length; i++) {
        if (stack.length == 0 || map[s[i]] != stack[stack.length - 1])
            stack.push(s[i]);
        else
            stack.pop()
    }
    return stack.length == 0;
};