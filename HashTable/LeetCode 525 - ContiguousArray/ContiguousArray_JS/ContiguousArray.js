/**
 * @param {number[]} nums
 * @return {number}
 */
var findMaxLength = function (nums) {
    var map = { 0: -1 }
    var zero = 0, one = 0, res = 0
    for (let i = 0; i < nums.length; i++) {
        nums[i] == 0 ? zero++ : one++
        if (map[zero - one] != undefined)
            res = Math.max(res, i - map[zero - one])
        else
            map[zero - one] = i
    }
    return res
}
