/**
 * @param {Array} arr
 * @param {number} size
 * @return {Array[]}
 */
var chunk = function(arr, size) {
    var res = []
    for (let i = 0; i < arr.length; i++) {
        if (i % size == 0)
            res.push([])
        res[res.length - 1].push(arr[i])
    }
    return res
}
