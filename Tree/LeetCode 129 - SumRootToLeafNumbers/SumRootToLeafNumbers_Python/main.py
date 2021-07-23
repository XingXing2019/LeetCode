# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    res = 0

    def sumNumbers(self, root: TreeNode) -> int:
        self.dfs(root, 0)
        return self.res

    def dfs(self, node: TreeNode, num: int):
        if not node:
            return
        if not node.left and not node.right:
            self.res += num * 10 + node.val
        self.dfs(node.left, num * 10 + node.val)
        self.dfs(node.right, num * 10 + node.val)
