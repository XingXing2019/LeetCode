# Definition for a binary tree node.
from typing import Optional


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    res = 0

    def pathSum(self, root: Optional[TreeNode], targetSum: int) -> int:
        map = {0: 1}
        self.dfs(root, targetSum, 0, map)
        return self.res

    def dfs(self, node, targetSum, sum, map):
        if not node:
            return
        sum += node.val
        if sum - targetSum in map:
            self.res += map[sum - targetSum]
        if sum not in map:
            map[sum] = 0
        map[sum] += 1
        self.dfs(node.left, targetSum, sum, map)
        self.dfs(node.right, targetSum, sum, map)
        map[sum] -= 1


a = TreeNode(10)
b = TreeNode(5)
c = TreeNode(-3)
d = TreeNode(3)

a.left = b
a.right = c
b.left = d
targetSum = 8
sol = Solution()
print(sol.pathSum(a, targetSum))
