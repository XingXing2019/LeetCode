/**
 * @param {string} s
 * @param {number} k
 * @return {string}
 */
var truncateSentence = function (s, k) {
    var words = s.split(' ');
    var res = '';
    var index = 0;
    while (index < words.length && k != 0) {
        if (words[index] === '') continue;
        res += words[index++];
        k--;
        if (k != 0) res += ' ';
    }
    return res;
};