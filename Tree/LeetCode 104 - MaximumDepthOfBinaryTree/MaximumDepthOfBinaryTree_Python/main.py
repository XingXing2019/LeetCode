# Definition for a binary tree node.
from typing import Optional


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def maxDepth(self, root: Optional[TreeNode]) -> int:
        return self.dfs(root)

    def dfs(self, node: Optional[TreeNode]) -> int:
        if not node:
            return 0
        left = self.dfs(node.left)
        right = self.dfs(node.right)
        return max(left, right) + 1
