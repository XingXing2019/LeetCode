/**
 * @param {string} pattern
 * @param {string} s
 * @return {boolean}
 */
var wordPattern = function (pattern, s) {
    var words = s.split(' ')
    if (words.length != pattern.length)
        return false
    var mapWord = {}, mapPattern = {}
    for (let i = 0; i < words.length; i++) {
        if (!mapWord[words[i]] && !mapPattern[pattern[i]]) {
            mapWord[words[i]] = pattern[i]
            mapPattern[pattern[i]] = words[i]
        }
        else if (mapWord[words[i]] != pattern[i])
            return false
        else if (mapPattern[pattern[i]] != words[i])
            return false
    }
    return true
}
