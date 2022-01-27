/**
 * @param {number[]} heights
 * @return {number[]}
 */
var canSeePersonsCount = function (heights) {
    var res = []
    for (let i = 0; i < heights.length; i++)
        res[i] = 0
    var stack = []
    for (let i = 0; i < heights.length; i++) {
        while (stack.length != 0 && heights[stack[stack.length - 1]] < heights[i]) {
            var index = stack.pop()
            res[index]++
        }
        if (stack.length != 0) {
            var index = stack[stack.length - 1]
            res[index]++
        }
        stack.push(i)
    }
    return res
}
