function ListNode(val, next) {
  this.val = val === undefined ? 0 : val
  this.next = next === undefined ? null : next
}

/**
 * @param {ListNode} head
 * @param {number} k
 * @return {ListNode}
 */
var rotateRight = function (head, k) {
    var getLen = function (head) {
        var res = 0
        while (head) {
            res++
            head = head.next
        }
        return res
    }
    var dummy = new ListNode(0, head), fast = dummy, slow = dummy
    var len = getLen(head)
    k %= len
    if (k == 0) return head
    for (let i = 0; i < k; i++) 
        fast = fast.next
    while (fast && fast.next) {
        slow = slow.next
        fast = fast.next
    }
    var res = slow.next
    slow.next = fast.next
    fast.next = dummy.next
    return res
}
