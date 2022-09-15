/**
 * @param {number[]} changed
 * @return {number[]}
 */
var findOriginalArray = function (changed) {
    if (changed.length % 2 != 0) return []
    changed.sort((a, b) => a - b)
    var res = []
    var map = new Map()
    changed.forEach(x => {
        if (!map.has(x))
            map.set(x, 0)
        map.set(x, map.get(x) + 1)
    })
    for (let i = changed.length - 1; i >= 0; i--) {
        if (map.get(changed[i]) == 0) continue
        if (!map.has(changed[i] / 2) || map.get(changed[i] / 2) == 0)  
            return []
        res.push(changed[i] / 2)
        map.set(changed[i], map.get(changed[i]) - 1)
        map.set(changed[i] / 2, map.get(changed[i] / 2) - 1)
    }
    return res
}