class ListNode:

    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def isPalindrome(self, head: Optional[ListNode]) -> bool:
        reversedHead = None
        pointer = head
        while pointer:
            reversedHead = ListNode(pointer.val, reversedHead)
            pointer = pointer.next
        while reversedHead:
            if reversedHead.val != head.val:
                return False
            reversedHead = reversedHead.next
            head = head.next
        return True
