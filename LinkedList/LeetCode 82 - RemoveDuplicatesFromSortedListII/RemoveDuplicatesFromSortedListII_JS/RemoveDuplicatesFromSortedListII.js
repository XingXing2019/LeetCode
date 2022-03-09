function ListNode(val, next) {
  this.val = val === undefined ? 0 : val
  this.next = next === undefined ? null : next
}

/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var deleteDuplicates = function (head) {
    if (head == null) return null
    var dummy = new ListNode(0, head), point = head.next
    var seen = new Set()
    while (point != null) {
        if (head.val == point.val) {
            seen.add(head.val)
        } else {
            head.next = point
            head = head.next
        }
        point = point.next
    }
    head.next = null
    head = dummy.next
    point = dummy
    while (head != null) {
        if (!seen.has(head.val)) {
            point.next = head
            point = point.next
        }
        head = head.next
    }
    point.next = head
    return dummy.next
}
