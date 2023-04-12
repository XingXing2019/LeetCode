/**
 * @param {number[]} nums
 * @param {Function} fn
 * @param {number} init
 * @return {number}
 */
var reduce = function(nums, fn, init) {
    var cur = init
    for (let i = 0; i < nums.length; i++)
        cur = fn(cur, nums[i])
    return cur
};