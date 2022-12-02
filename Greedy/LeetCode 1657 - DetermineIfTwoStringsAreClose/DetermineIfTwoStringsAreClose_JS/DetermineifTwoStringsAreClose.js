/**
 * @param {string} word1
 * @param {string} word2
 * @return {boolean}
 */
var closeStrings = function(word1, word2) {
    if (word1.length != word2.length) 
        return false
    var letters1 = new Array(26).fill(0)
    var letters2 = new Array(26).fill(0)
    var a = 'a'.charCodeAt(0)
    for (let i = 0; i < word1.length; i++) {
        letters1[word1.charCodeAt(i) - a]++
        letters2[word2.charCodeAt(i) - a]++        
    }
    var map = new Map()
    for (let i = 0; i < letters1.length; i++) {
        if (letters1[i] == 0 && letters2[i] != 0 || letters1[i] != 0 && letters2[i] == 0)
            return false
        if (!map.has(letters1[i]))
            map.set(letters1[i], 0)
        map.set(letters1[i], map.get(letters1[i]) + 1)
        if (!map.has(letters2[i]))        
            map.set(letters2[i], 0)
        map.set(letters2[i], map.get(letters2[i]) - 1)
    }
    for (const [key, value] of map) {
        if (value != 0)
            return false
    }
    return true
}