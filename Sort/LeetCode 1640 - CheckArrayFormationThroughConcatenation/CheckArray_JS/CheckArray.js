/**
 * @param {number[]} arr
 * @param {number[][]} pieces
 * @return {boolean}
 */
var canFormArray = function(arr, pieces) {
    var map = new Map()
    for (let i = 0; i < pieces.length; i++)
        map.set(pieces[i][0], pieces[i])
    var p1 = 0
    while (p1 < arr.length) {
        if (!map.has(arr[p1]))
            return false
        var p2 = 0
        var nums = map.get(arr[p1])
        while (p1 < arr.length && p2 < nums.length) {
            if (arr[p1++] != nums[p2++])
                return false
        }
    }
    return p1 == arr.length
}