/**
 * @param {number[]} arr
 * @return {boolean}
 */
var uniqueOccurrences = function(arr) {
    var map = new Map()
    for (let i = 0; i < arr.length; i++) {
        if (!map.has(arr[i]))
            map.set(arr[i], 0)
        map.set(arr[i], map.get(arr[i]) + 1)        
    }
    var set = new Set()
    for (const [key, value] of map) {
        if (set.has(value))
            return false
        set.add(value)
    }
    return true
}