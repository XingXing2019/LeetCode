from typing import List


class Solution:
    def threeSum(nums: List[int]) -> List[List[int]]:
        res = []
        if len(nums) == 0:
            return res
        nums.sort()
        last = nums[0] - 1
        for i in range(len(nums) - 2):
            if nums[i] == last:
                continue
            last = nums[i]
            li, hi = i + 1, len(nums) - 1
            while li < hi:
                if nums[i] + nums[li] + nums[hi] == 0:
                    res.append([nums[i], nums[li], nums[hi]])
                    while li < hi and nums[li] == res[-1][1]:
                        li += 1
                    while li < hi and nums[hi] == res[-1][2]:
                        hi -= 1
                elif nums[i] + nums[li] + nums[hi] > 0:
                    hi -= 1
                else:
                    li += 1
        return res

    nums = [-1, 0, 1, 2, -1, -4]
    threeSum(nums)
