function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}
/**
 * @param {ListNode} head
 * @return {ListNode}
 */
var sortLinkedList = function (head) {
    var pos = new ListNode(), neg = new ListNode();
    var posPoint = pos, negPoint = neg;
    while (head != null){
        if (head.val > 0){
            posPoint.next = head;
            posPoint = posPoint.next;
        } else {
            negPoint.next = head;
            negPoint = negPoint.next;
        }
        head = head.next;
    }
    posPoint.next = null;
    negPoint.next = null;
    negPoint = neg.next;
    while (negPoint != null && negPoint.next != null){
        var next = negPoint.next;
        negPoint.next = next.next;
        next.next = neg.next;
        neg.next = next;
    }
    if (negPoint == null) return pos.next;
    negPoint.next = pos.next;
    return neg.next;
};