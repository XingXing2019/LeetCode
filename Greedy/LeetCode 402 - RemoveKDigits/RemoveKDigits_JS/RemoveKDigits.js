/**
 * @param {string} num
 * @param {number} k
 * @return {string}
 */
var removeKdigits = function (num, k) {
    var stack = []
    for (let i = 0; i < num.length; i++) {
        while (k > 0 && stack.length != 0 && num[stack[stack.length - 1]] > num[i]) {
            stack.pop()
            k--
        }
        stack.push(i)
    }
    while (k != 0 && stack.length != 0) {
        stack.pop()
        k--
    }
    while (stack.length != 0 && num[stack[0]] == '0')
        stack.shift()
    var res = ''
    while (stack.length != 0)
        res = num[stack.pop()] + res
    return res == '' ? '0' : res
}
