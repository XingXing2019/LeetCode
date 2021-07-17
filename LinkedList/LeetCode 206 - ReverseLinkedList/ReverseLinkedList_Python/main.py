# Definition for singly-linked list.
 class ListNode:
     def __init__(self, val=0, next=None):
         self.val = val
         self.next = next
class Solution:
    def reverseList(self, head: ListNode) -> ListNode:
        dummy = ListNode(0, head)
        while head is not None and head.next is not None:
            next = head.next
            head.next = next.next
            next.next = dummy.next
            dummy.next = next
        return dummy.next