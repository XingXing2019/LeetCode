/**
 * @param {string} palindrome
 * @return {string}
 */
var breakPalindrome = function (palindrome) {
    if (palindrome.length == 1) return ''
    var letters = [...palindrome]
    var half = Math.floor(letters.length / 2)
    for (let i = 0; i < half; i++) {
        if (letters[i] != 'a') {
            letters[i] = 'a'
            return letters.join('')
        }            
    }
    letters[letters.length - 1] = 'b'
    return letters.join('')
};