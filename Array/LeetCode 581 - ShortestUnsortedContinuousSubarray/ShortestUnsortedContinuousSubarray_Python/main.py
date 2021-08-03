import math


class Solution:
    def findUnsortedSubarray(self, nums: List[int]) -> int:
        leftMax, rightMin, left, right = -math.inf, math.inf,len(nums) - 1, 0
        for i in range(0, len(nums)):
            if nums[i] < leftMax:
                right = i
            leftMax = max(leftMax, nums[i])
            if nums[-(i + 1)] > rightMin:
                left = len(nums) - i - 1
            rightMin = min(rightMin, nums[-(i + 1)])
        return 0 if right <= left else right - left + 1
