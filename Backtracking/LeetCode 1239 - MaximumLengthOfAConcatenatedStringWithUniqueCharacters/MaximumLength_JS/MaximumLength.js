/**
 * @param {string[]} arr
 * @return {number}
 */
var maxLength = function (arr) {
    var res = 0
    var isValid = function (word, mask) {
        for (let i = 0; i < word.length; i++) {
            var index = word.charCodeAt(i) - 'a'.charCodeAt(0)
            if (((mask >> index) & 1) == 1)
                return false
            mask += (1 << index)
        }
        return true
    }
    var dfs = function (words, start, mask, len) {
        res = Math.max(res, len)
        for (let i = start; i < words.length; i++) {
            var word = words[i]
            var temp = mask
            if (!isValid(word, mask)) continue
            for (let j = 0; j < word.length; j++) {
                var index = word.charCodeAt(j) - 'a'.charCodeAt(0)
                mask += (1 << index)
            }
            dfs (words, i + 1, mask, len + word.length)
            mask = temp
        }
    }
    dfs(arr, 0, 0, 0)
    return res
};