/**
 * @param {number[]} pushed
 * @param {number[]} popped
 * @return {boolean}
 */
var validateStackSequences = function (pushed, popped) {
    var stack = []
    var p1 = 0, p2 = 0
    while (p1 < pushed.length && p2 < popped.length) {
        if (stack.length == 0 || stack[stack.length - 1] != popped[p2])
            stack.push(pushed[p1++])
        if (stack[stack.length - 1] == popped[p2]) {
            stack.pop()
            p2++
        }
    }
    while (p2 < popped.length && stack[stack.length - 1] == popped[p2]) {
        stack.pop()
        p2++
    }
    return p2 == popped.length && stack.length == 0
}
