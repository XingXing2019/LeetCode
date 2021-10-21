var threeSum = function (nums) {
    nums.sort(function(a, b) {return a - b});
    let res = [];
    let last = nums[0] - 1;
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] === last)
            continue;
        last = nums[i];
        let li = i + 1, hi = nums.length - 1;
        while (li < hi) {
            if (nums[i] + nums[li] + nums[hi] === 0) {
                res.push([nums[i], nums[li], nums[hi]]);
                let temp = nums[li];
                while (li < hi && nums[li] == temp)
                    li++;
            } else if (nums[i] + nums[li] + nums[hi] > 0)
                hi--;
            else
                li++;
        }
    }
    return res;
};

console.log(new threeSum([-1, 0, 1, 2, -1, -2, 3, 0, 4]));