/**
 * @param {string[]} words
 * @return {number}
 */
var maxProduct = function (words) {
    var masks = new Array(words.length);
    for (var i = 0; i < words.length; i++) {
        for (var j = 0; j < words[i].length; j++)
            masks[i] |= 1 << (words[i].charCodeAt(j) - 97);
    }
    var res = 0;
    for (var i = 0; i < masks.length; i++) {
        for (var j = 0; j < masks.length; j++) {
            if (i === j || (masks[i] & masks[j]) !== 0)
                continue;
            res = Math.max(res, words[i].length * words[j].length);
        }
    }
    return res;
};

var words = ["abcw", "baz", "foo", "bar", "xtfn", "abcdef"];
console.log(maxProduct(words));