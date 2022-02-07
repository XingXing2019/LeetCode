/**
 * @param {string} s
 * @param {string} t
 * @return {character}
 */
var findTheDifference = function (s, t) {
    var record = []
    for (let i = 0; i < t.length; i++) {
        var index = t[i].charCodeAt(0) - 'a'.charCodeAt(0)
        if (record[index] == undefined)
            record[index] = 0
        record[index]++
    }
    for (let i = 0; i < s.length; i++) {
        var index = s[i].charCodeAt(0) - 'a'.charCodeAt(0)
        record[index]--
    }
    for (let i = 0; i < record.length; i++) {
        if (record[i] == 1)
            return String.fromCharCode(i + 'a'.charCodeAt(0))   
    }
}
