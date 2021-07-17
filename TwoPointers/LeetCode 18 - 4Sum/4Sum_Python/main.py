from typing import List


class Solution:
    def fourSum(nums: List[int], target: int) -> List[List[int]]:
        res = []
        nums.sort()
        lastI = nums[0] - 1
        for i in range(len(nums) - 3):
            if nums[i] == lastI:
                continue
            lastI = nums[i]
            lastJ = nums[i + 1] - 1
            for j in range(i + 1, len(nums) - 2):
                if nums[j] == lastJ:
                    continue
                lastJ = nums[j]
                li, hi = j + 1, len(nums) - 1
                while li < hi:
                    if nums[i] + nums[j] + nums[li] + nums[hi] == target:
                        res.append([nums[i], nums[j], nums[li], nums[hi]])
                        while li < hi and nums[li] == res[-1][2]:
                            li += 1
                        while li < hi and nums[hi] == res[-1][3]:
                            hi -= 1
                    elif nums[i] + nums[j] + nums[li] + nums[hi] > target:
                        hi -= 1
                    else:
                        li += 1
        return res


    nums = [1, 0, -1, 0, -2, 2]
    target = 0
    print(fourSum(nums, target))
