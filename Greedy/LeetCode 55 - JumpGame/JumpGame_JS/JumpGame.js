/**
 * @param {number[]} nums
 * @return {boolean}
 */
var canJump = function(nums) {
    var reach = 0
    for (let i = 0; i < nums.length; i++) {
        reach = Math.max(reach, i + nums[i])
        if (reach == i && reach < nums.length - 1)
            return false
    }
    return reach >= nums.length - 1
}