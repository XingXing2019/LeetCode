class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution:
    def addTwoNumbers(self, l1: ListNode, l2: ListNode) -> ListNode:
        res = ListNode()
        point = res
        cur, car = 0, 0
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
        if car != 0:
            point.next = ListNode(car)
        return res.next
