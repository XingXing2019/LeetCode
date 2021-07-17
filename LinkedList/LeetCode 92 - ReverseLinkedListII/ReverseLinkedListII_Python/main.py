# Definition for singly-linked list.
 class ListNode:
     def __init__(self, val=0, next=None):
         self.val = val
         self.next = next
class Solution:
    def reverseBetween(self, head: ListNode, left: int, right: int) -> ListNode:
        dummy = ListNode(0, head)
        pre = dummy
        for i in range(left - 1):
            head = head.next
            pre = pre.next
        for i in range(right - left):
            next = head.next
            head.next = next.next
            next.next = pre.next
            pre.next = next
        return dummy.next