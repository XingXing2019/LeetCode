# Definition for a binary tree node.
import math


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def goodNodes(self, root: TreeNode) -> int:
        return self.dfs(root, -math.inf)

    def dfs(self, node: TreeNode, max_val: int) -> int:
        if not node:
            return 0
        res = 0 if node.val < max_val else 1
        res += self.dfs(node.left, max(max_val, node.val))
        res += self.dfs(node.right, max(max_val, node.val))
        return res


a = TreeNode(3)
b = TreeNode(3)
c = TreeNode(4)
d = TreeNode(2)

a.left = b
b.left = c
b.right = d

sol = Solution()
print(sol.goodNodes(a))
