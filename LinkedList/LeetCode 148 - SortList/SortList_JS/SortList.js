/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var sortList = function (head) {
    var dummy = new ListNode(0, head)
    while (head && head.next) {
        if (head.val < head.next.val) {
            head = head.next
        } else {
            var next = head.next
            head.next = head.next.next
            var point = dummy
            while (point.next != head && point.next.val < next.val)
                point = point.next
            next.next = point.next
            point.next = next
        }
    }
    return dummy.next
}
