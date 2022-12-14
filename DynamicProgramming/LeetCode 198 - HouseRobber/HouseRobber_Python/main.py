class Solution:
    def rob(self, nums: List[int]) -> int:
        for i in range(1, len(nums)):
            nums[i] = max(nums[i - 1], nums[i]) if i == 1 else max(nums[i - 1], nums[i] + nums[i - 2])
        return nums[-1]
