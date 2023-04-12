/**
 * @param {number[]} arr
 * @param {Function} fn
 * @return {number[]}
 */
var filter = function(arr, fn) {
    var res = []
    for (let i = 0; i < arr.length; i++) {
        if (!fn(arr[i], i)) continue
        res.push(arr[i])
    }
    return res
}