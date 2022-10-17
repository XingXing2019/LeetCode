/**
 * @param {string} sentence
 * @return {boolean}
 */
var checkIfPangram = function(sentence) {
    var letters = new Array(26).fill(false)
    for (let i = 0; i < sentence.length; i++) {
        var index = sentence.charCodeAt(i) - 'a'.charCodeAt(0)
        letters[index] = true        
    }
    return !letters.some(x => !x)
}