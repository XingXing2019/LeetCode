/**
 * @param {string} s
 * @return {number}
 */
var countHomogenous = function(s) {
    var li = 0, hi = 0, res = 0, mod = 1_000_000_000 + 7
    var map = new Map()
    while (hi < s.length) {
        if (!map.has(s[hi]))
            map.set(s[hi], 0)
        map.set(s[hi], map.get(s[hi]) + 1)
        if (map.size != 1)
            res += (map.get(s[li]) + 1) * map.get(s[li]) / 2
        while (li < hi && map.size != 1) {
            map.set(s[li], map.get(s[li]) - 1)
            if (map.get(s[li]) == 0)
                map.delete(s[li])
            li++
        }
        hi++
    }
    res += (map.get(s[li]) + 1) * map.get(s[li]) / 2
    return res % mod
}