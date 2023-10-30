/**
 * @param {number[]} arr
 * @return {number[]}
 */
var sortByBits = function (arr) {
    var map = new Map()
    arr.forEach(num => {
        map.set(num, countBit(num))
    });
    arr.sort((a, b) => {
        if (map.get(a) < map.get(b))
            return -1
        if (map.get(a) > map.get(b))
            return 1
        return a - b
    })
    return arr
}

var countBit = function (num) {
    var res = 0
    while (num != 0) {
        res += num & 1
        num >>= 1
    } 
    return res
}