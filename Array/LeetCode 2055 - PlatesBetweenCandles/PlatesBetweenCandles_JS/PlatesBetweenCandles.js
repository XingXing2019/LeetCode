/**
 * @param {string} s
 * @param {number[][]} queries
 * @return {number[]}
 */
var platesBetweenCandles = function (s, queries) {
    var leftCandle = [], rightCandle = [], plates = []
    var left = -1, right = -1, count = 0
    for (let i = 0; i < s.length; i++) {
        if (s[i] == '|') left = i
        else count++
        plates[i] = count
        leftCandle[i] = left
    }
    for (let i = s.length - 1; i >= 0; i--) {
        if (s[i] == '|') right = i
        rightCandle[i] = right
    }
    var res = []
    queries.forEach(x => {
        var hi = leftCandle[x[1]], li = rightCandle[x[0]]
        count = hi == -1 || li == -1 ? 0 : plates[hi] - plates[li]
        res.push(Math.max(0, count))
    })
    return res
}
