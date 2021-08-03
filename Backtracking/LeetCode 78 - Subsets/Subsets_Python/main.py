from typing import List


class Solution:
    def subsets(self, nums: List[int]) -> List[List[int]]:
        res = []
        self.dfs(res, nums, [], 0)
        return res

    def dfs(self, res: List[List[int]], nums: List[int], items: List[int], start: int) -> None:
        res.append(items.copy())
        for i in range(start, len(nums)):
            items.append(nums[i])
            self.dfs(res, nums, items, i + 1)
            items.pop()
