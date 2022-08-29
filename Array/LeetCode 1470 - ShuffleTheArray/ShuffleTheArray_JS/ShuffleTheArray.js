/**
 * @param {number[]} nums
 * @param {number} n
 * @return {number[]}
 */
var shuffle = function (nums, n) {
    var res = []
    var p1 = 0, p2 = n, index = 0
    for (let i = 0; i < n; i++) {
        res[index++] = nums[p1++]
        res[index++] = nums[p2++]
    }
    return res
}
