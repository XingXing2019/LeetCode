/**
 * @param {number[]} nums
 * @return {number}
 */
var maxSubarraySumCircular = function(nums) {
    var max = 0, min = 0, sum = 0;
    var continueMax = -Number.MAX_VALUE, continueMin = Number.MAX_VALUE
    nums.forEach(num => {
        max = Math.max(max + num, num)
        min = Math.min(min + num, num)
        continueMax = Math.max(continueMax, max)
        continueMin = Math.min(continueMin, min)
        sum += num
    })
    return sum == continueMin ? continueMax : Math.max(continueMax, sum - continueMin)
}