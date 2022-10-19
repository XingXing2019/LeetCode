/**
 * @param {string[]} words
 * @param {number} k
 * @return {string[]}
 */
var topKFrequent = function(words, k) {
    var unique = []
    var map = new Map()
    for (let i = 0; i < words.length; i++) {
        if (!map.has(words[i])) {
            map.set(words[i], 0)
            unique.push(words[i])
        }
        map.set(words[i], map.get(words[i]) + 1)
    }
    unique.sort((a, b) => map.get(a) == map.get(b) ? a.localeCompare(b) : map.get(b) - map.get(a))
    return unique.slice(0, k)
}