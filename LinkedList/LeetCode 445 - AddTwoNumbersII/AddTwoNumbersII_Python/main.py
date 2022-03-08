class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def addTwoNumbers(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        l1 = self.reverse(l1)
        l2 = self.reverse(l2)
        dummy = ListNode()
        point = dummy
        car, cur = 0, 0
        while l1 is not None and l2 is not None:
            cur = (l1.val + l2.val + car) % 10
            car = (l1.val + l2.val + car) // 10
            point.next = ListNode(cur)
            point = point.next
            l1 = l1.next
            l2 = l2.next
            if l1 is None and l2 is not None:
                l1 = ListNode()
            if l1 is not None and l2 is None:
                l2 = ListNode()
        if car == 1:
            point.next = ListNode(car)
        return self.reverse(dummy.next)

    def reverse(self, head):
        dummy = ListNode(0, head)
        while head.next is not None:
            next = head.next
            head.next = next.next
            next.next = dummy.next
            dummy.next = next
        return dummy.next
