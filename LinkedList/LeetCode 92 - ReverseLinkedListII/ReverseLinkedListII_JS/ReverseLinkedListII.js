function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}
/**
 * @param {ListNode} head
 * @param {number} left
 * @param {number} right
 * @return {ListNode}
 */
var reverseBetween = function (head, left, right) {
    var dummy = new ListNode(0, head);
    var pre = dummy;
    for (let i = 0; i < left - 1; i++) {
        pre = pre.next;
        head = head.next;
    }
    for (let i = 0; i < right - left; i++) {
        var next = head.next;
        head.next = next.next;
        next.next = pre.next
        pre.next = next;
    }
    return dummy.next;
};