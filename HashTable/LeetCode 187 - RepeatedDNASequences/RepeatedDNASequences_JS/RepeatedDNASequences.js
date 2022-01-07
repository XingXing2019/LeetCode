/**
 * @param {string} s
 * @return {string[]}
 */
var findRepeatedDnaSequences = function (s) {
    if (s.length < 10) return []
    var mask = 1000000000, window = 0
    var map = { A: 1, C: 2, G: 3, T: 4 }
    for (let i = 0; i < 10; i++)
        window = window * 10 + map[s[i]]
    var li = 0, hi = 9
    var set = new Set(), res = [], added = new Set()
    set.add(window)
    while (hi < s.length - 1) {
        window = (window - mask * map[s[li++]]) * 10 + map[s[++hi]]
        if (set.has(window) && !added.has(window)) {
            added.add(window)
            res.push(s.substring(li, hi + 1))
        }
        else
            set.add(window)
    }
    return res
}
