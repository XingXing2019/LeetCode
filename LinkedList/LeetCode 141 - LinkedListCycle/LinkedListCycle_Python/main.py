# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None


class Solution:
    def hasCycle(self, head: ListNode) -> bool:
        fast, slow = head, head
        while fast is not None and slow is not None:
            fast = fast.next
            if fast is None:
                return False
            fast = fast.next
            slow = slow.next
            if fast == slow:
                return True
        return False
