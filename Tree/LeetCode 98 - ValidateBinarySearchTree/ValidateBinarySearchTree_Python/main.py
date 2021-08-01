# Definition for a binary tree node.
import math


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def isValidBST(self, root: TreeNode) -> bool:
        return self.dfs(root, 2147483648, -2147483649)

    def dfs(self, node: TreeNode, minVal: int, maxVal: int) -> bool:
        if not node:
            return True
        if node.val >= minVal or node.val <= maxVal:
            return False
        return self.dfs(node.left, node.val, maxVal) and self.dfs(node.right, minVal, node.val)


a = TreeNode(5)
b = TreeNode(4)
c = TreeNode(6)
d = TreeNode(3)
e = TreeNode(7)

a.left = b
a.right = c
c.left = d
c.right = e

sol = Solution()
print(sol.isValidBST(a))
