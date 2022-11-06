/**
 * @param {string} s
 * @param {number} k
 * @return {string}
 */
var orderlyQueue = function(s, k) {
    if (k != 1)
        return orderString(s)
    var set = new Set()
    var res = s
    while (!set.has(s)) {
        set.add(s)
        s = s.substring(1) + s[0]
        if (s.localeCompare(res) < 0)
            res = s
    }
    return res
}

var orderString = function(s) {
    var res = ''
    var a = 'a'.charCodeAt(0)
    var letters = new Array(26).fill(0)
    for (let i = 0; i < s.length; i++)
        letters[s.charCodeAt(i) - a]++
    for (let i = 0; i < letters.length; i++) {
        var letter = String.fromCharCode(a + i);
        res += letter.repeat(letters[i])
    }
    return res
}