# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def deleteDuplicates(self, head: ListNode) -> ListNode:
        if head is None:
            return head
        dummy = ListNode(0, head)
        p1, p2 = dummy.next, head.next
        while p2 is not None:
            if p2.val != p1.val:
                p1.next = p2
                p1 = p1.next
            p2 = p2.next
        p1.next = None
        return dummy.next
