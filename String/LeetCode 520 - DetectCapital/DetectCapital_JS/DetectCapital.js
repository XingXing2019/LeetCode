/**
 * @param {string} word
 * @return {boolean}
 */
var detectCapitalUse = function (word) {
    var isUpper = function (letter) {
        return letter == letter.toUpperCase()
    }
    var countUpper = 0
    for (let i = 0; i < word.length; i++)
        countUpper += isUpper(word[i]) ? 1 : 0
    return isUpper(word[0]) ? countUpper == 1 || countUpper == word.length : countUpper == 0
}
