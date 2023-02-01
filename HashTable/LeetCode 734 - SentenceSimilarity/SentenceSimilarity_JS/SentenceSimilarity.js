/**
 * @param {string[]} sentence1
 * @param {string[]} sentence2
 * @param {string[][]} similarPairs
 * @return {boolean}
 */
var areSentencesSimilar = function(sentence1, sentence2, similarPairs) {
    if (sentence1.length != sentence2.length)
        return false
    var map = {}
    similarPairs.forEach(pair => {
        if (!map[pair[0]])
            map[pair[0]] = new Set()
        map[pair[0]].add(pair[1])
        if (!map[pair[1]])
            map[pair[1]] = new Set()
        map[pair[1]].add(pair[0])
    })
    for (let i = 0; i < sentence1.length; i++) {        
        if (sentence1[i] != sentence2[i] && (!map[sentence1[i]] || !map[sentence1[i]].has(sentence2[i])))
            return false        
    }
    return true
}