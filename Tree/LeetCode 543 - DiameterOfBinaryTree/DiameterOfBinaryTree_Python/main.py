# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    res = 0

    def diameterOfBinaryTree(self, root: TreeNode) -> int:
        if not root:
            return 0
        self.getDepth(root)
        return self.res

    def getDepth(self, node: TreeNode) -> int:
        if not node:
            return 0
        left = self.getDepth(node.left)
        right = self.getDepth(node.right)
        self.res = max(self.res, left + right)
        return max(left, right) + 1
