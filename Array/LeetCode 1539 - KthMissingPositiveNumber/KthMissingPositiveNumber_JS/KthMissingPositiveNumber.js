/**
 * @param {number[]} arr
 * @param {number} k
 * @return {number}
 */
var findKthPositive = function(arr, k) {
    var li = 0, hi = arr.length
    while (li < hi) {
        var mid = li + ~~((hi - li) / 2)
        if (arr[mid] - (mid + 1) < k)
            li = mid + 1
        else
            hi = mid
    }
    return k + li
}