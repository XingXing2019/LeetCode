/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
var threeSumClosest = function (nums, target) {    
    nums.sort((a, b) => { return a - b })
    var res = 0, gap = Number.MAX_VALUE, last = nums[0] - 1;
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] === last) continue;
        last = nums[i]
        var li = i + 1, hi = nums.length - 1;
        while (li < hi) {
            var sum = nums[i] + nums[li] + nums[hi]
            if (sum === target) return sum
            if (Math.abs(sum - target) < gap) {
                gap = Math.abs(sum - target)
                res = sum
            }
            if (sum > target)
                hi--;
            else
                li++;
        }        
    }
    return res
}
