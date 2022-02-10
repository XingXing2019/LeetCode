/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var subarraySum = function (nums, k) {
    for (let i = 1; i < nums.length; i++)
        nums[i] += nums[i - 1]
    var map = { 0: 1 }
    var res = 0
    nums.forEach(num => {
        if (map[num - k] != undefined)
            res += map[num - k]
        if (map[num] == undefined)
            map[num] = 0
        map[num]++
    })
    return res
}
