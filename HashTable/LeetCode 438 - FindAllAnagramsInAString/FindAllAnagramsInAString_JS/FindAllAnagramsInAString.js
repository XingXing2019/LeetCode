/**
 * @param {string} s
 * @param {string} p
 * @return {number[]}
 */
var findAnagrams = function (s, p) {
    var res = []
    if (p.length > s.length) return res
    var target = 0, hash = 0, mod = 1_000_000_000 + 7
    var getPow = function (l) {
        return l.charCodeAt(0) - 'a'.charCodeAt(0)
    }
    for (let i = 0; i < p.length; i++) {
        target += Math.pow(26, getPow(p[i])) % mod
        hash += Math.pow(26, getPow(s[i])) % mod
    }
    var li = 0, hi = p.length    
    while (hi < s.length) {
        if (hash == target) res.push(li)
        hash += Math.pow(26, getPow(s[hi++])) % mod
        hash -= Math.pow(26, getPow(s[li++])) % mod
    }
    if (hash == target) res.push(li)
    return res
}
