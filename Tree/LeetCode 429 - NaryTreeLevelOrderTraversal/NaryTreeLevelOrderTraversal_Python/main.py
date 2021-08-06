import asyncio
from typing import List


class Node:
    def __init__(self, val=None, children=None):
        self.val = val
        self.children = children


class Solution:
    def levelOrder(self, root: 'Node') -> List[List[int]]:
        res, queue = [], []
        if not root:
            return res
        queue.append(root)
        while len(queue) != 0:
            count = len(queue)
            temp = []
            for i in range(count):
                cur = queue.pop(0)
                temp.append(cur.val)
                for child in cur.children:
                    if child:
                        queue.append(child)
            res.append(temp)
        return res
