from typing import List


class NumArray:

    def __init__(self, nums: List[int]):
        self.prefix = [0] * len(nums)
        sum = 0
        for i in range(len(self.prefix)):
            sum += nums[i]
            self.prefix[i] = sum

    def sumRange(self, left: int, right: int) -> int:
        return self.prefix[right] if left == 0 else self.prefix[right] - self.prefix[left - 1]


nums = [-2, 0, 3, -5, 2, -1]
arr = NumArray(nums)
arr.sumRange(0, 2)
