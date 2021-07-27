from typing import List


class Solution:
    def threeSumClosest(nums: List[int], target: int) -> int:
        nums.sort()
        res, min, last = 0, 1000000, nums[0] - 1
        for i in range(len(nums) - 2):
            if nums[i] == last:
                continue
            last = nums[i]
            li, hi = i + 1, len(nums) - 1
            while li < hi:
                sum = nums[i] + nums[li] + nums[hi]
                if sum == target:
                    return target
                if abs(sum - target) < min:
                    min = abs(sum - target)
                    res = sum
                if sum > target:
                    hi -= 1
                else:
                    li += 1
        return res

    nums = [-1, 2, 1, -4]
    target = 1
    threeSumClosest(nums, target)
