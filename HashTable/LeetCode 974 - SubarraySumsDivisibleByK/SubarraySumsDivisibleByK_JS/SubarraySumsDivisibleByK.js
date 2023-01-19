/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var subarraysDivByK = function(nums, k) {
    var map = {0 : 1}, res = 0, sum = 0
    nums.forEach(num => {
        sum += num
        var mod = sum % k < 0 ? sum % k + k : sum % k
        if (!map[mod])
            map[mod] = 0
        res += map[mod]
        map[mod]++
    })
    return res
}