/**
 * @param {number[]} nums
 * @return {number}
 */
var maxAscendingSum = function(nums) {
    var res = nums[0], sum = nums[0]   
    for (let i = 1; i < nums.length; i++) {
        if (nums[i] > nums[i - 1]) {
            sum += nums[i]
            res = Math.max(res, sum)
        } else {
            sum = nums[i]
        }        
    }
    return res
}