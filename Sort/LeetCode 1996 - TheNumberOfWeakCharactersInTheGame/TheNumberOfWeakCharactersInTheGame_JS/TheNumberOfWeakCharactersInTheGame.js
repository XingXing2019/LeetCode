/**
 * @param {number[][]} properties
 * @return {number}
 */
var numberOfWeakCharacters = function (properties) {
    properties.sort((a, b) => { return a[0] == b[0] ? b[1] - a[1] : a[0] - b[0] })
    var stack = []
    var res = 0
    for (let i = 0; i < properties.length; i++) {
        while (
            stack.length != 0 &&
            properties[i][0] > properties[stack[stack.length - 1]][0] &&
            properties[i][1] > properties[stack[stack.length - 1]][1]
        ) {
            res++
            stack.pop()
        }
        stack.push(i)
    }
    return res
}
