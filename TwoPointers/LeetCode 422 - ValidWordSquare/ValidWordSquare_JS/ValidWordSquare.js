/**
 * @param {string[]} words
 * @return {boolean}
 */
var validWordSquare = function (words) {    
    for (let i = 0; i < words.length; i++) {
        for (let j = 0; j < words[i].length; j++) {
            if (j >= words.length) return false
            if (words[i][j] == words[j][i]) continue
            return false
        }
    }
    return true
};