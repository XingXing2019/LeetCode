/**
 * @param {number[]} nums
 * @param {number} k
 * @return {boolean}
 */
var canPartitionKSubsets = function (nums, k) {
    var sum = 0
    for (let i = 0; i < nums.length; i++)
        sum += nums[i]
    if (sum % k != 0) return false
    var dfs = function (nums, index, bucket, target) {
        if (index == nums.length) {
            return allEqualsTarget(bucket, target)
        }
        for (let i = 0; i < bucket.length; i++) {
            if (bucket[i] + nums[index] > target)
                continue
            bucket[i] += nums[index]
            if (dfs(nums, index + 1, bucket, target))
                return true
            bucket[i] -= nums[index]            
        }
        return false
    }
    var allEqualsTarget = function (bucket, target) {
        for (let i = 0; i < bucket.length; i++) {
            if (bucket[i] != target)
                return false
        }
        return true
    }
    nums.sort((a, b) => b - a)
    return dfs(nums, 0, new Array(k).fill(0), sum / k)
}