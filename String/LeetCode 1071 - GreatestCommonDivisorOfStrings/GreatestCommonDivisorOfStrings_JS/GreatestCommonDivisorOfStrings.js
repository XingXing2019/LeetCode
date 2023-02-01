/**
 * @param {string} str1
 * @param {string} str2
 * @return {string}
 */
var gcdOfStrings = function(str1, str2) {
    var divisor1 = getDivisor(str1)
    var divisor2 = getDivisor(str2)
    for (const divisor of divisor1) {
        if (divisor2.has(divisor))
            return divisor
    }
    return ""
}

var getDivisor = function (str) {
    var res = new Set()
    for (let i = str.length; i >= 1; i--) {
        if (str.length % i != 0) continue
        var sub = str.substring(0, i)
        var isDivisor = true, start = 0
        for (let j = 0; j < str.length / i; j++) {
            if (str.substring(start, start + sub.length) != sub) {
                isDivisor = false
                break
            }
            start += sub.length
        }
        if (isDivisor) res.add(sub)
    }
    return res
}