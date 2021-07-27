# Definition for a binary tree node.
import math


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    firstMin, secondMin = math.inf, math.inf

    def findSecondMinimumValue(self, root: TreeNode) -> int:
        self.dfs(root)
        return -1 if self.secondMin == math.inf else self.secondMin

    def dfs(self, root: TreeNode) -> None:
        if not root:
            return
        if root.val < self.firstMin:
            self.secondMin = self.firstMin
            self.firstMin = root.val
        elif root.val < self.secondMin and root.val != self.firstMin:
            self.secondMin = root.val
        self.dfs(root.left)
        self.dfs(root.right)


a = TreeNode(2)
b = TreeNode(2)
c = TreeNode(5)
d = TreeNode(5)
e = TreeNode(7)

a.left = b
a.right = c
c.left = d
c.right = e

sol = Solution()
print(sol.findSecondMinimumValue(a))
