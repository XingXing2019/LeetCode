function ListNode(val, next) {
  this.val = val === undefined ? 0 : val
  this.next = next === undefined ? null : next
}
/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var swapPairs = function (head) {
    var dummy = new ListNode(0, head), point = dummy
    while (head && head.next) {
        var next = head.next
        head.next = next.next
        next.next = point.next
        point.next = next
        point = head
        head = head.next
    }
    return dummy.next
}
