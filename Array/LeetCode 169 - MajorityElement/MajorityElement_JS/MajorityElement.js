/**
 * @param {number[]} nums
 * @return {number}
 */
var majorityElement = function (nums) {
    var res = nums[0], count = 0
    nums.forEach(num => {
        count += num == res ? 1 : -1
        if (count == 0) {
            res = num
            count = 1
        }
    })
    return res
}
