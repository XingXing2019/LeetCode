/**
 * @param {string} s
 * @return {number}
 */
var minOperations = function(s) {
    return Math.min(count(s, 1), count(s, 0))
}

var count = function (s, start) {
    var res = 0
    for (let i = 0; i < s.length; i++) {
        var digit = s.charCodeAt(i) - '0'.charCodeAt(0)
        if (digit != start)
            res++
        start ^= 1
    }
    return res
}