/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var largestSumAfterKNegations = function (nums, k) {
    nums.sort((a, b) => {return a - b});
    var index = 0;
    while (index < nums.length && nums[index] < 0 && k !== 0) {
        nums[index++] *= -1;
        k--;
    }
    var res = 0;
    nums.forEach(x => {
        res += x;
    });
    if (k % 2 === 0) return res;
    if (index === 0)
        return res - 2 * nums[index];
    else if (index === nums.length)
        return res - 2 * nums[index - 1];
    return res - 2 * (Math.min(nums[index], nums[index - 1]));    
};