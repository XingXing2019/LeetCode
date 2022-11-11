/**
 * @param {string} s
 * @return {boolean}
 */
var halvesAreAlike = function (s) {
    var vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U']
    var count = 0
    for (let i = 0; i < s.length / 2; i++) {
        if (vowels.includes(s[i]))
            count++
        if (vowels.includes(s[i + s.length / 2]))
            count--
    }
    return count == 0
}