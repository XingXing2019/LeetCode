from typing import List


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def sortedArrayToBST(self, nums: List[int]) -> TreeNode:
        return self.dfs(nums, 0, len(nums) - 1)

    def dfs(self, nums: List[int], li: int, hi: int) -> TreeNode:
        if li > hi:
            return None
        mid = li + (hi - li) // 2
        left = self.dfs(nums, li, mid - 1)
        right = self.dfs(nums, mid + 1, hi)
        root = TreeNode(nums[mid], left, right)
        return root
