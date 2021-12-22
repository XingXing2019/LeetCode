function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}

/**
 * @param {ListNode} head
 * @return {void} Do not return anything, modify head in-place instead.
 */
var reorderList = function (head) {
    var point = head;
    var reverse = function(head) {
        var res = null;
        while (head != null) {
            res = new ListNode(head.val, res);
            head = head.next;
        }
        return res;
    }
    var reversed = reverse(point);
    var dummy = new ListNode(), point = dummy;
    while (head != null) {
        point.next = head;
        head = head.next;
        point = point.next;
        point.next = reversed;
        reversed = reversed.next;
        point = point.next;
    }
    var slow = dummy.next, fast = dummy.next;
    while (fast != null) {
        fast = fast.next;
        fast = fast.next;
        if (fast == null) break;
        slow = slow.next;
    }
    slow.next = null;
    return dummy.next;
};