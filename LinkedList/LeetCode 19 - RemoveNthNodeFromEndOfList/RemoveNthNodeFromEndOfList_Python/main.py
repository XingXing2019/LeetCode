from typing import Optional


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def removeNthFromEnd(self, head: Optional[ListNode], n: int) -> Optional[ListNode]:
        reversed = self.reverse(head)
        dummy = ListNode(0, reversed)
        point = dummy
        for i in range(n - 1):
            point = point.next
            reversed = reversed.next
        point.next = reversed.next
        return self.reverse(dummy.next)

    def reverse(self, head):
        if head is None:
            return head
        dummy = ListNode(0, head)
        while head is not None and head.next is not None:
            pro = head.next
            head.next = pro.next
            pro.next = dummy.next
            dummy.next = pro
        return dummy.next