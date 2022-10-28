/**
 * @param {string[]} strs
 * @return {string[][]}
 */
var groupAnagrams = function(strs) {
    var getKey = function (str) {
        var freq = new Array(26).fill(0)
        for (let i = 0; i < str.length; i++)
            freq[str.charCodeAt(i) - 'a'.charCodeAt(0)]++
        var key = ''
        for (let i = 0; i < freq.length; i++) {
            var letter = String.fromCharCode('a'.charCodeAt(0) + i)
            key += `${letter}${freq[i]}`
        }
        return key
    }
    var map = new Map()
    strs.forEach(x => {
        var key = getKey(x)
        if (!map.has(key))
            map.set(key, [])
        map.get(key).push(x)
    })
    var res = []
    for (const [key, value] of map)
        res.push(value)
    return res
}