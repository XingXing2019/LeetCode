/**
 * @param {number[]} target
 * @param {number[]} arr
 * @return {boolean}
 */
var canBeEqual = function (target, arr) {
    var map = new Map()
    for (let i = 0; i < target.length; i++) {
        if (!map.has(target[i]))
            map.set(target[i], 0)
        map.set(target[i], map.get(target[i]) + 1)
        if (!map.has(arr[i]))
            map.set(arr[i], 0)
        map.set(arr[i], map.get(arr[i]) - 1)
    }
    for (const [key, value] of map) {
        if (value == 0) continue
        return false
    }
    return true
}
