from typing import List


class Solution:
    def subsetsWithDup(self, nums: List[int]) -> List[List[int]]:
        res = []
        items = []
        nums.sort()
        self.dfs(res, nums, items, 0)
        return res

    def dfs(self, res: List[List[int]], nums: List[int], items: List[int], start: int) -> None:
        res.append(items.copy())
        for i in range(start, len(nums)):
            if i > start and nums[i] == nums[i - 1]:
                continue
            items.append(nums[i])
            self.dfs(res, nums, items, i + 1)
            items.pop()


sol = Solution()
nums = [1, 2, 2]
print(sol.subsetsWithDup(nums))
