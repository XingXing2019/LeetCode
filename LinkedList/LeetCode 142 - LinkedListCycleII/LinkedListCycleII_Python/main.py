# Definition for singly-linked list.
from typing import List


class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None


def generate(nums, pos) -> ListNode:
    nodes = []
    for i in range(len(nums)):
        nodes.append(ListNode(nums[i]))
        if i != 0:
            nodes[i - 1].next = nodes[i]
    nodes[-1].next = nodes[pos]
    return nodes[0]


class Solution:
    def detectCycle(head: ListNode) -> ListNode:
        fast, slow = head, head
        while fast is not None and slow is not None:
            fast = fast.next
            if fast is None:
                return None
            fast = fast.next
            slow = slow.next
            if slow == fast:
                break
        if fast is None:
            return None
        while head != slow:
            head = head.next
            slow = slow.next
        return head


    nums = [3, 2, 0, 4]
    pos = 1
    head = generate(nums, pos)
    detectCycle(head)
