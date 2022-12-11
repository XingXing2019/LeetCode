/**
 * @param {string} s
 * @return {number}
 */
var beautySum = function(s) {
    var res = 0
    for (let i = 0; i < s.length; i++) {
        for (let j = i + 1; j < s.length; j++) {
            res += count(s.substring(i, j + 1))
        }        
    }
    return res
}

var count = function (s) {
    var letters = new Array(26).fill(0)
    for (let i = 0; i < s.length; i++)
        letters[s.charCodeAt(i) - 'a'.charCodeAt(0)]++
    var max = 0, min = s.length
    for (let i = 0; i < letters.length; i++) {
        if (letters[i] == 0) continue
        max = Math.max(max, letters[i])
        min = Math.min(min, letters[i])
    }
    return max != 0 && min != s.length ? max - min : 0
}