/**
 * @param {string} s1
 * @param {string} s2
 * @return {boolean}
 */
var checkInclusion = function (s1, s2) {
    if (s1.length > s2.length) return false
    var check = function (letters1, letters2) {
        for (let i = 0; i < letters1.length; i++) {
            if (letters1[i] != letters2[i])
                return false            
        }
        return true
    }
    var letters1 = [], letters2 = []
    for (let i = 0; i < 26; i++) {
        letters1.push(0)
        letters2.push(0)
    }
    for (let i = 0; i < s1.length; i++) {
        letters1[s1[i].charCodeAt(0) - 'a'.charCodeAt(0)]++
        letters2[s2[i].charCodeAt(0) - 'a'.charCodeAt(0)]++
    }
    for (let i = 0; i < s2.length - s1.length; i++) {
        if (check(letters1, letters2)) return true
        letters2[s2[i].charCodeAt(0) - 'a'.charCodeAt(0)]--
        letters2[s2[i + s1.length].charCodeAt(0) - 'a'.charCodeAt(0)]++
    }
    return check(letters1, letters2)
}
