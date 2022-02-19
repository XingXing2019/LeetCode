/**
 * @param {number[]} arr
 * @return {number[]}
 */
var pancakeSort = function (arr) {
    var target = arr.length
    var res = []
    var filp = function (arr, index) {
        var li = 0, hi = index
        while (li < hi) {
            var temp = arr[li]
            arr[li++] = arr[hi]
            arr[hi--] = temp
        }
    }
    while (target != 1) {
        var index = arr.indexOf(target)
        res.push(index + 1)
        filp(arr, index)
        res.push(target)
        filp(arr, target - 1)
        target--
    }
    return res
}
