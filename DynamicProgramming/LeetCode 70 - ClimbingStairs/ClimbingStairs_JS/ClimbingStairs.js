/**
 * @param {number} n
 * @return {number}
 */
var climbStairs = function (n) { 
    var first = 1, second = 1
    for (let i = 1; i < n; i++) {
        var temp = first + second
        second = first
        first = temp
    }
    return first
}