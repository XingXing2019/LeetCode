class Solution:
    def nextGreaterElements(self, nums: List[int]) -> List[int]:
        res = [-1] * len(nums)
        stack = []
        for i in range(2):
            for j in range(len(nums)):
                while len(stack) != 0 and nums[j] > nums[stack[-1]]:
                    res[stack.pop()] = nums[j]
                stack.append(j)
        return res
