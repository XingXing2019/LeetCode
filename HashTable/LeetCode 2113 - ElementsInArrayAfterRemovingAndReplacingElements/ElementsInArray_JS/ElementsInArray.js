/**
 * @param {number[]} nums
 * @param {number[][]} queries
 * @return {number[]}
 */
var elementInNums = function (nums, queries) {
    var record = [], res = [];
    for (let i = 0; i < nums.length * 2; i++) {
        if (i <= nums.length)
            record.push(i);
        else 
            record.push(i - nums.length - 1);
    }
    for (let i = 0; i < queries.length; i++) {
        var time = queries[i][0] % record.length;
        var index = queries[i][1];
        if (time <= nums.length)
            res[i] = index + record[time] < nums.length ? nums[index + record[time]] : -1;
        else 
            res[i] = index <= record[time] ? nums[index] : -1;
    }
    return res;
};