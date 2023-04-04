/**
 * @param {string} s
 * @return {number}
 */
var partitionString = function (s) {
    var res = 0
    var letters = new Array(26).fill(0)
    var a = 'a'.charCodeAt(0)
    for (let i = 0; i < s.length; i++) {
        var letter = s.charCodeAt(i) - a
        if (letters[letter] == 0)
            letters[letter]++
        else {
            letters = new Array(26).fill(0)
            letters[letter] = 1
            res++
        }
    }
    return res + 1
}