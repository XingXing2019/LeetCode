/**
 * @param {number[]} heights
 * @return {number}
 */
var largestRectangleArea = function (heights) {
    var stack = [], left = []
    var res = 0
    for (let i = 0; i < heights.length; i++) {        
        left[i] = 0
        while (stack.length != 0 && heights[i] < heights[stack[stack.length - 1]]) {
            var index = stack.pop()
            var len = i - index + left[index]
            res = Math.max(res, heights[index] * len)            
            left[i] = len
        }
        stack.push(i)
    }
    while (stack.length != 0) {
        var index = stack.pop()
        var len = heights.length - index + left[index]
        res = Math.max(res, heights[index] * len)
    }
    return res
}
