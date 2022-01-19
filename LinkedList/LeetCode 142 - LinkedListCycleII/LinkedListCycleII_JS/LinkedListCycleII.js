function ListNode(val) {
  this.val = val
  this.next = null
}

/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var detectCycle = function (head) {
    var fast = head, slow = head
    while (fast && fast.next) {
        fast = fast.next
        slow = slow.next
        fast = fast.next
        if (fast === slow) break
    }
    if (!fast || !fast.next) return null
    while (head != slow) {
        head = head.next
        slow = slow.next
    }
    return head
}
