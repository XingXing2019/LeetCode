/**
 * @param {string} sentence
 * @return {number}
 */
var countValidWords = function (sentence) {
    var isValid = function (word) {
        var count = 0
        for (let i = 0; i < word.length; i++) {
            if (!isNaN(parseInt(word[i])))
                return false
            if ((word[i] == '!' || word[i] == '.' || word[i] == ',') && i != word.length - 1)
                return false
            if (word[i] == '-') {
                count++
                if (i == 0 || i == word.length - 1)
                    return false
                if (!word[i - 1].match(/[a-z]/) || !word[i + 1].match(/[a-z]/))
                    return false
            }       
        }
        return count < 2
    }
    var words = sentence.split(' ')
    var res = 0
    words.forEach(word => {
        if (word != '' && isValid(word)) res++
    })
    return res
}
