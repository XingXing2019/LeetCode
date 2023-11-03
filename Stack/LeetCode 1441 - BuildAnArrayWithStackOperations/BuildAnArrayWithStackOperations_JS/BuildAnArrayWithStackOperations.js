/**
 * @param {number[]} target
 * @param {number} n
 * @return {string[]}
 */
var buildArray = function(target, n) {
    var res = []
    var index = 0, start = 1
    while (index < target.length) {
        res.push('Push')
        if (target[index] == start)
            index++
        else
            res.push('Pop')
        start++   
    }
    return res
}   