/**
 * @param {string[]} ops
 * @return {number}
 */
var calPoints = function (ops) {
    var stack = []
    for (let i = 0; i < ops.length; i++) {
        if (ops[i] == '+') {
            stack.push(stack[stack.length - 1] + stack[stack.length - 2])
        } else if (ops[i] == 'C') {
            stack.pop()
        } else if (ops[i] == 'D') {
            stack.push(2 * stack[stack.length - 1])
        } else {
            stack.push(parseInt(ops[i]))
        }        
    }
    var res = 0;
    for (let i = 0; i < stack.length; i++) {
        res += stack[i];        
    }
    return res
}
