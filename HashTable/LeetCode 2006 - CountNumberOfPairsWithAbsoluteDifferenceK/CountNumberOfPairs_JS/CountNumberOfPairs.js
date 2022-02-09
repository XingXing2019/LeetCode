/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var countKDifference = function (nums, k) {
    var map = {}
    var res = 0
    nums.forEach(num => {
        if (map[num + k] != undefined)
            res += map[num + k]
        if (map[num - k] != undefined)
            res += map[num - k]
        if (map[num] == undefined)
            map[num] = 0
        map[num]++
    })
    return res
}
