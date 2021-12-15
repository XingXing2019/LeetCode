function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}
/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var insertionSortList = function (head) {
    if (!head) return null;
    var dummy = new ListNode(0, head);
    while (head.next != null) {
        if (head.val <= head.next.val) 
            head = head.next;
        else {
            var point = dummy, next = head.next;
            while (point.next.val <= next.val)
                point = point.next;
            head.next = next.next;
            next.next = point.next;
            point.next = next;
        }
    }
    return dummy.next;
};