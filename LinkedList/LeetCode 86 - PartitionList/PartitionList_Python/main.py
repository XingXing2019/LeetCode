# Definition for singly-linked list.
 class ListNode:
     def __init__(self, val=0, next=None):
         self.val = val
         self.next = next
class Solution:
    def partition(self, head: ListNode, x: int) -> ListNode:
        if head is None:
            return head
        less, greater = ListNode(), ListNode();
        lessHead, greaterHead = less, greater
        while head is not None:
            if head.val < x:
                less.next = head
                less = less.next
            else:
                greater.next = head
                greater = greater.next
            head = head.next
        greater.next = None
        less.next = greaterHead.next
        return lessHead.next
