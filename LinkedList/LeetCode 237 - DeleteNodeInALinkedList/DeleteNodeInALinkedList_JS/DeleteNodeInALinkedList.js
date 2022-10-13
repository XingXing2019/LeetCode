function ListNode(val) {
    this.val = val;
    this.next = null;
}

var deleteNode = function(node) {
    node.val = node.next.val
    node.next = node.next.next
}