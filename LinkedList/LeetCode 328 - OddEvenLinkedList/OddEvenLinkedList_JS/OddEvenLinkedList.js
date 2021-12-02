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
var oddEvenList = function (head) {
    var oddHead = new ListNode(), oddPoint = oddHead;
    var evenHead = new ListNode(), evenPoint = evenHead;
    var index = 1;
    while (head != null) {
        if (index % 2 == 0) {
            evenPoint.next = head;
            evenPoint = evenPoint.next;
        } else {
            oddPoint.next = head;
            oddPoint = oddPoint.next;
        }
        head = head.next;
        index++;
    }
    oddPoint.next = evenHead.next;
    evenPoint.next = null;
    return oddHead.next;
};