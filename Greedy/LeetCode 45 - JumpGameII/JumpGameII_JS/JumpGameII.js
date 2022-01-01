/**
 * @param {number[]} nums
 * @return {number}
 */
 var jump = function(nums) {
     var cur = 0, reach = nums[0], res = 1
     if (cur === nums.length - 1) return 0
     while (reach < nums.length - 1) {
         var jumpTo = 0, max = reach
         for (let i = cur; i < nums.length && i <= reach; i++) {
             if (i + nums[i] > max) {
                 max = i + nums[i]
                 jumpTo = i
             }
         }
         cur = jumpTo
         reach = max
         res++
     }
     return res
};