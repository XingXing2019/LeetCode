function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}
/**
 * @param {ListNode} head
 * @param {number} val
 * @return {ListNode}
 */
var removeElements = function (head, val) {
    var dummy = new ListNode(0, head);
    var pre = dummy;
    while (head != null) {
        if (head.val != val){
            pre.next = head;
            pre = pre.next;
        }
        head = head.next;
    }
    pre.next = null;
    return dummy.next;
};