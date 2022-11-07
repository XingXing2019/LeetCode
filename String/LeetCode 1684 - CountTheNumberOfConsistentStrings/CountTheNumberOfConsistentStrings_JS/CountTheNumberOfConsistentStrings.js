/**
 * @param {string} allowed
 * @param {string[]} words
 * @return {number}
 */
var countConsistentStrings = function (allowed, words) {
    var a = 'a'.charCodeAt(0)
    var res = 0
    var letters = new Array(26).fill(false)
    for (let i = 0; i < allowed.length; i++)
        letters[allowed.charCodeAt(i) - a] = true
    for (let i = 0; i < words.length; i++) {
        var isValid = true
        for (let j = 0; j < words[i].length; j++) {
            if (letters[words[i].charCodeAt(j) - a]) continue
            isValid = false
            break
        }
        if (!isValid) continue
        res++
    }
    return res
}