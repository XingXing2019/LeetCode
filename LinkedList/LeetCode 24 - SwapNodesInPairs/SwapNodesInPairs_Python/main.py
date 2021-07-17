# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def swapPairs(self, head: ListNode) -> ListNode:
        dummy = ListNode(0, head)
        point = dummy
        while point is not None and point.next is not None:
            first, second = point.next, point.next.next
            if second is None:
                break
            first.next = second.next
            second.next = point.next
            point.next = second
            point = first
        return dummy.next
