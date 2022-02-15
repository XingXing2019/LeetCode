/**
 * @param {number[]} nums
 * @return {number}
 */
var singleNumber = function (nums) {
    var res = 0
    nums.forEach((num) => { res ^= num })
    return res
}
