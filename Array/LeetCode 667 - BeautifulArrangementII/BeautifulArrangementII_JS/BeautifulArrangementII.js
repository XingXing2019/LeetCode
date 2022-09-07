/**
 * @param {number} n
 * @param {number} k
 * @return {number[]}
 */
var constructArray = function(n, k) {
    var res = []
    for (let i = 1; i <= n; i++)
        res.push(i)
    var reverse = function (arr, start) {
        var li = start, hi = arr.length - 1
        while (li < hi) {
            var temp = arr[li]
            arr[li++] = arr[hi]
            arr[hi--] = temp
        }
    }
    for (let i = 1; i < k; i++)
        reverse(res, i)
    return res
}