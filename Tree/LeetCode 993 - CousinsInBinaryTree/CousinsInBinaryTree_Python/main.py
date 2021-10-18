# Definition for a binary tree node.
from collections import deque
from typing import Optional


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def isCousins_bfs(self, root: Optional[TreeNode], x: int, y: int) -> bool:
        queue = deque()
        queue.append([root, None])
        while len(queue) != 0:
            count = len(queue)
            cousin1, cousin2 = None, None
            for i in range(count):
                cur = queue.popleft()
                if cur[0].val == x or cur[0].val == y:
                    if not cousin1:
                        cousin1 = cur
                    elif not cousin2:
                        cousin2 = cur
                if cur[0].left:
                    queue.append([cur[0].left, cur[0]])
                if cur[0].right:
                    queue.append([cur[0].right, cur[0]])
            if cousin1 and cousin2:
                return cousin1[1] != cousin2[1]
        return False

    xParent = None
    yParent = None
    xLevel = 0
    yLevel = 0

    def isCousins_dfs(self, root: Optional[TreeNode], x: int, y: int) -> bool:
        self.dfs(root, None, x, y, 0)
        return self.xLevel == self.yLevel and self.xParent != self.yParent

    def dfs(self, node, parent, x, y, level):
        if not node:
            return
        if node.val == x:
            self.xParent = parent
            self.xLevel = level
        if node.val == y:
            self.yParent = parent
            self.yLevel = level
        self.dfs(node.left, node, x, y, level + 1)
        self.dfs(node.right, node, x, y, level + 1)


a = TreeNode(1)
b = TreeNode(2)
c = TreeNode(3)
d = TreeNode(4)
e = TreeNode(5)

a.left = b
a.right = c
b.right = d
c.right = e

x, y = 5, 4

sol = Solution()
print(sol.isCousins_dfs(a, x, y))