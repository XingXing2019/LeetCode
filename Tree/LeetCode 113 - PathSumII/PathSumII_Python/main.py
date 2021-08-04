# Definition for a binary tree node.
from typing import List


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def pathSum(self, root: TreeNode, targetSum: int) -> List[List[int]]:
        res = []
        self.dfs(root, targetSum, 0, res, [])
        return res

    def dfs(self, node: TreeNode, targetSum: int, sum: int, res: List[List[int]], nums: List[int]) -> None:
        if not node:
            return
        if node.left == node.right and sum + node.val == targetSum:
            nums.append(node.val)
            res.append(nums.copy())
            nums.pop()
        nums.append(node.val)
        self.dfs(node.left, targetSum, sum + node.val, res, nums)
        self.dfs(node.right, targetSum, sum + node.val, res, nums)
        nums.pop()


sol = Solution()
a = TreeNode(1)
b = TreeNode(2)
c = TreeNode(3)

a.left = b
a.right = c
target = 3
print(sol.pathSum(a, target))