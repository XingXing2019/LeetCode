/**
 * @param {string} num
 * @return {boolean}
 */
var isStrobogrammatic = function(num) {
    var map = new Map()
    map.set('0', '0')
    map.set('1', '1')
    map.set('6', '9')
    map.set('8', '8')
    map.set('9', '6')
    var li = 0, hi = num.length - 1
    while (li <= hi) {
        if (!map.has(num[li]) || map.get(num[li]) != num[hi])
            return false
        li++
        hi--
    }
    return true
}   