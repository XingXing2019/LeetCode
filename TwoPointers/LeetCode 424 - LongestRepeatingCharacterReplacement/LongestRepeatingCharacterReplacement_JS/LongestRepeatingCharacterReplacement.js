/**
 * @param {string} s
 * @param {number} k
 * @return {number}
 */
var characterReplacement = function (s, k) {
    var map = new Map()
    var li = 0, hi = 0, res = 0
    var valid = function (k) {
        if (map.size < 2) return true
        var max = 0, sum = 0
        map.forEach(x => {
            max = Math.max(max, x)
            sum += x
        })
        return sum - max <= k
    }
    while (hi < s.length) {
        if (!map.has(s[hi]))
            map.set(s[hi], 0)
        map.set(s[hi], map.get(s[hi]) + 1)
        while (li < hi && !valid(k)) {
            map.set(s[li], map.get(s[li]) - 1)
            if (map.get(s[li]) === 0)
                map.delete(s[li])
            li++
        }
        res = Math.max(res, hi - li + 1)
        hi++
    }
    return res
}
