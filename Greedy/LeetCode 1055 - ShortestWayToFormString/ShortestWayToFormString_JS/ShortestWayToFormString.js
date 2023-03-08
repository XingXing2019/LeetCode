/**
 * @param {string} source
 * @param {string} target
 * @return {number}
 */
var shortestWay = function (source, target) {
    var set = new Set()
    for (let i = 0; i < source.length; i++)
        set.add(source[i])
    var p1 = 0, p2 = 0, res = 0
    while (p1 < target.length) {
        if (!set.has(target[p1]))
            return -1
        if (p2 == source.length) {
            res++
            p2 = 0
        }
        if (target[p1] == source[p2])
            p1++
        p2++ 
    }
    return res + 1
}