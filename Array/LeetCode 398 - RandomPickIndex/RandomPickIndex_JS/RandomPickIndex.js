/**
 * @param {number[]} nums
 */
var Solution = function (nums) {
    Solution.prototype.nums = nums;
};

/** 
 * @param {number} target
 * @return {number}
 */
Solution.prototype.pick = function (target) {
    var res = -1;
    var count = 0;
    for (let i = 0; i < this.nums.length; i++) {
        if (this.nums[i] === target) {
            count++;
            if (parseInt(Math.random() * count) === 0)
                res = i;
        }        
    }
    return res;
};
