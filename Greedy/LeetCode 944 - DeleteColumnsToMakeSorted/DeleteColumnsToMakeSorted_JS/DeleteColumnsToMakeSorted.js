/**
 * @param {string[]} strs
 * @return {number}
 */
var minDeletionSize = function (strs) {
    var res = 0;
    for (let j = 0; j < strs[0].length; j++) {
        for (let i = 1; i < strs.length; i++) {
            if (strs[i].charAt(j) >= strs[i - 1].charAt(j)) continue
            res++
            break
        }
    }
    return res
}