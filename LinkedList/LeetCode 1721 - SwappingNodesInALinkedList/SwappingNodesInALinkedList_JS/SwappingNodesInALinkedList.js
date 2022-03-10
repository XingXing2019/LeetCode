function ListNode(val, next) {
  this.val = val === undefined ? 0 : val
  this.next = next === undefined ? null : next
}
/**
 * @param {ListNode} head
 * @param {number} k
 * @return {ListNode}
 */
var swapNodes = function (head, k) {
    var fast = head, slow = head, res = head
    for (let i = 0; i < k; i++) 
        fast = fast.next
    while (fast) {
        fast = fast.next
        slow = slow.next
    }
    for (let i = 0; i < k - 1; i++)
        head = head.next
    var temp = head.val
    head.val = slow.val
    slow.val = temp
    return res
}
