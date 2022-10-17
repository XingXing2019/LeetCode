/**
 * @param {number[]} fruits
 * @return {number}
 */
var totalFruit = function(fruits) {
    var map = new Map()
    var li = 0, hi = 0, res = 0
    while (hi < fruits.length) {
        if (!map.has(fruits[hi]))
            map.set(fruits[hi], 0)
        map.set(fruits[hi], map.get(fruits[hi]) + 1)
        while (li < hi && map.size > 2) {
            map.set(fruits[li], map.get(fruits[li]) - 1)
            if (map.get(fruits[li]) == 0)
                map.delete(fruits[li])
            li++
        }
        res = Math.max(res, hi - li + 1)
        hi++
    }
    return res
}