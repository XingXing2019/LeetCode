/**
 * @param {string} text
 * @return {number}
 */
var maxNumberOfBalloons = function (text) {
    var map = {
        'b': 0,
        'a': 0,
        'l': 0,
        'o': 0,
        'n': 0
    }
    for (let i = 0; i < text.length; i++) {
        if (map[text[i]] == undefined) continue
        map[text[i]]++
    }
    var res = text.length
    for (const key in map) {
        if (key == 'l' || key == 'o')
            res = Math.min(res, ~~(map[key] / 2))
        else
            res = Math.min(res, map[key])
    }
    return res
}
