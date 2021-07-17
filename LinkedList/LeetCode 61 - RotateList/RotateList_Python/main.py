# Definition for singly-linked list.
from typing import List


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def rotateRight(head: ListNode, k: int) -> ListNode:
        if head is None:
            return head
        def getLen(head: ListNode) -> int:
            res = 0
            while head is not None:
                res += 1
                head = head.next
            return res
        fast, slow = head, head
        len = getLen(head)
        k %= len
        if k == 0:
            return head
        for i in range(k):
            fast = fast.next
        while fast.next is not None:
            fast = fast.next
            slow = slow.next
        res = slow.next
        slow.next = None
        fast.next = head
        return res

    def generate(nums: List[int]) -> ListNode:
        res = None
        for i in range(len(nums) - 1, -1, -1):
            res = ListNode(nums[i], res)
        return res

    nums = [1]
    head = generate(nums)
    print(rotateRight(head, 1))
