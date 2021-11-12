function ListNode(val, next) {
    this.val = (val === undefined ? 0 : val)
    this.next = (next === undefined ? null : next)
}
/**
 * @param {ListNode} head
 * @return {number[]}
 */
var nodesBetweenCriticalPoints = function (head) {
    var index = 1, first = 100000, last = -1, cur = -1;
    var res = [100000, -1];
    var point = head.next;
    while (point.next != null) {
        var next = point.next;
        if ((point.val < head.val && point.val < next.val) || (point.val > head.val && point.val > next.val)) {
            first = Math.min(first, index);
            last = Math.max(last, index);
            if (cur != -1)
                res[0] = Math.min(res[0], index - cur);
            cur = index;
            res[1] = Math.max(res[1], last - first);
        }
        point = point.next;
        head = head.next;
        index++;
    }
    if (first == Number.MAX_VALUE || last == -1 || first == last)
        return [-1, -1];
    return res;
};