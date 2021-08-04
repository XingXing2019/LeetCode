# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def hasPathSum(self, root: TreeNode, targetSum: int) -> bool:
        return self.dfs(root, targetSum, 0)

    def dfs(self, node: TreeNode, targetSum: int, sum: int) -> bool:
        if not node:
            return False
        if node.left == node.right and sum + node.val == targetSum:
            return True
        return self.dfs(node.left, targetSum, sum + node.val) or self.dfs(node.right, targetSum, sum + node.val)
