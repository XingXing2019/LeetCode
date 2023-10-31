/**
 * @param {number[]} pref
 * @return {number[]}
 */
var findArray = function(pref) {
    var res = [pref[0]]
    for (let i = 1; i < pref.length; i++)
        res[i] = pref[i - 1] ^ pref[i]
    return res
}