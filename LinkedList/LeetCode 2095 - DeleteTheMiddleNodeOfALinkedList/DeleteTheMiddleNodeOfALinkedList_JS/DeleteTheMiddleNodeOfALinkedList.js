function ListNode(val, next) {
    this.val = (val===undefined ? 0 : val)
    this.next = (next===undefined ? null : next)
}

var deleteMiddle = function (head) {
    var dummy = new ListNode(0, head)
    var point = dummy
    var fast = head, slow = head
    while (fast && fast.next) {
        fast = fast.next.next
        slow = slow.next
        point = point.next
    }
    point.next = slow.next
    return dummy.next
}