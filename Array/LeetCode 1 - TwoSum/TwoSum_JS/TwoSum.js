var twoSum = function(nums, target) {
    let map = new Map();
    for (let i = 0; i < nums.length; i++) {
        if (map.has(target - nums[i]))
            return [map.get(target - nums[i]), i];
        map.set(nums[i], i);
    }
    return null;
};

let nums = [2, 7, 11, 15];
let target = 9;
console.log(new twoSum(nums, target));