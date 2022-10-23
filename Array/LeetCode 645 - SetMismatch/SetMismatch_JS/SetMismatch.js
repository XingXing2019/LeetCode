/**
 * @param {number[]} nums
 * @return {number[]}
 */
var findErrorNums = function(nums) {
    var set = new Set()
    var sum = 0
    var res = []
    nums.forEach(num => {
        sum += num
        if (set.has(num))
            res[0] = num
        set.add(num)
    })
    res[1] = (1 + nums.length) * nums.length / 2 - sum + res[0]
    return res
}