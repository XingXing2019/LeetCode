# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def pruneTree(self, root: TreeNode) -> TreeNode:
        return root if self.containsOne(root) else None

    def containsOne(self, node: TreeNode) -> bool:
        if node is None:
            return False
        left = self.containsOne(node.left)
        right = self.containsOne(node.right)
        if left is False:
            node.left = None
        if right is False:
            node.right = None
        return node.val == 1 or left or right
