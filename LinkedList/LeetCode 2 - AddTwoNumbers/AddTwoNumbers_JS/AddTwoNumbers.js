function ListNode(val, next) {
  this.val = val === undefined ? 0 : val
  this.next = next === undefined ? null : next
}
/**
 * @param {ListNode} l1
 * @param {ListNode} l2
 * @return {ListNode}
 */
var addTwoNumbers = function (l1, l2) {
    var dummy = new ListNode(), point = dummy
    var cur = 0, car = 0
    while (l1 && l2) {
        cur = (l1.val + l2.val + car) % 10
        car = ~~((l1.val + l2.val + car) / 10)
        point.next = new ListNode(cur)
        point = point.next
        l1 = l1.next
        l2 = l2.next
        if (!l1 && l2)
            l1 = new ListNode()
        if (l1 && !l2)
            l2 = new ListNode()
    }
    if (car != 0) point.next = new ListNode(car)
    return dummy.next
}
