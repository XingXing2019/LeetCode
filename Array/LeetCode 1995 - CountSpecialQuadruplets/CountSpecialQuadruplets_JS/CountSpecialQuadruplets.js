/**
 * @param {number[]} nums
 * @return {number}
 */
 var countQuadruplets = function(nums) {
    var map = new Map();
    var res = 0;
    for (let i = 0; i < nums.length; i++) {
        for (let j = 0; j < i; j++) {
            if (!map.has(nums[i] + nums[j]))
                map.set(nums[i] + nums[j], 0);
            map.set(nums[i] + nums[j], map.get(nums[i] + nums[j]) + 1);            
        }
        for (let j = i + 2; j < nums.length; j++) {
            if (map.has(nums[j] - nums[i + 1]))
                res += map.get(nums[j] - nums[i + 1]);            
        }        
    }
    return res;
};