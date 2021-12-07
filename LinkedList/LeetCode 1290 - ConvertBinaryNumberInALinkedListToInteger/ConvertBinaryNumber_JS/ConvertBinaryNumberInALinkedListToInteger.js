function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}
/**
 * @param {ListNode} head
 * @return {number}
 */
var getDecimalValue = function (head) {
    var reverse = function(head) {
        var dummy = new ListNode(0, head);
        while (head.next != null) {
            var next = head.next;
            head.next = next.next;
            next.next = dummy.next;
            dummy.next = next;
        }
        return dummy.next;
    }
    var reversed = reverse(head);
    var res = 0, pow = 1;
    while (reversed != null) {
        res += reversed.val * pow;
        pow *= 2;
        reversed = reversed.next;
    }
    return res;
};