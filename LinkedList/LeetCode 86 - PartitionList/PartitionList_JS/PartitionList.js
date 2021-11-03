function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}
/**
 * @param {ListNode} head
 * @param {number} x
 * @return {ListNode}
 */
var partition = function (head, x) {
    let small = new ListNode(), smallPoint = small;
    let large = new ListNode(), largePointer = large;
    while (head != null) {
        if (head.val < x) {
            smallPoint.next = head;
            smallPoint = smallPoint.next;
        } else {
            largePointer.next = head;
            largePointer = largePointer.next;
        }
        head = head.next;
    }
    smallPoint.next = large.next;
    largePointer.next = null;
    return small.next;
};