/**
 * @param {number[]} arr
 * @return {boolean}
 */
var validMountainArray = function (arr) {
    var li = 0, hi = arr.length - 1
    while (li != arr.length - 1 && arr[li + 1] >= arr[li])
        li++
    while (hi != 0 && arr[hi - 1] >= arr[hi])
        hi--
    return li == hi && li != 0 && hi != arr.length - 1
}
