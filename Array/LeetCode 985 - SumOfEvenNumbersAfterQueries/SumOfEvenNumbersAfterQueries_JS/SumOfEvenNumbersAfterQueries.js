/**
 * @param {number[]} nums
 * @param {number[][]} queries
 * @return {number[]}
 */
var sumEvenAfterQueries = function(nums, queries) {
    var res = []
    var sum = 0
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] % 2 != 0) continue
        sum += nums[i]
    }
    for (let i = 0; i < queries.length; i++) {
        var val = queries[i][0], index = queries[i][1], origin = nums[index]
        nums[index] += val
        if (nums[index] % 2 == 0)
            sum += origin % 2 == 0 ? val : nums[index]
        else
            sum -= origin % 2 == 0 ? origin : 0
        res.push(sum)
    }
    return res
}