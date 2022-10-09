class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def findTarget(self, root: Optional[TreeNode], k: int) -> bool:
        return self.dfs(root, k, set())

    def dfs(self, node, k, record):
        if not node:
            return False
        if k - node.val in record:
            return True
        record.add(node.val)
        return self.dfs(node.left, k, record) or self.dfs(node.right, k, record)
