# Definition for singly-linked list.
from typing import List


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


def generate(nums: List[int]) -> ListNode:
    res = None
    for i in range(len(nums) - 1, -1, -1):
        res = ListNode(nums[i], res)
    return res


class Solution:
    def reorderList(head: ListNode) -> None:
        def reverseList(head: ListNode) -> ListNode:
            res = None
            while head is not None:
                res = ListNode(head.val, res)
                head = head.next
            return res
        l1 = head
        l2 = reverseList(head)
        dummy = ListNode
        point = dummy
        while l1 is not None:
            point.next = l1
            point = point.next
            l1 = l1.next
            point.next = l2
            point = point.next
            l2 = l2.next
        slow, fast = head, head
        while fast is not None and fast.next is not None:
            fast = fast.next
            if fast.next is None:
                break
            fast = fast.next
            slow = slow.next
        slow.next = None

    nums = [1, 2, 3, 4, 5]
    head = generate(nums)
    reorderList(head)
