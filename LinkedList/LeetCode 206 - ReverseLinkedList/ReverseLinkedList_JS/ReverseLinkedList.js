function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}

/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var reverseList = function (head) {
    if (head === null) return null;
    var dummy = new ListNode(0, head);
    while (head.next != null) {
        var next = head.next;
        head.next = next.next;
        next.next = dummy.next;
        dummy.next = next;
    }
    return dummy.next;
};