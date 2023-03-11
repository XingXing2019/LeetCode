function ListNode(val, next) {
    this.val = val === undefined ? 0 : val;
    this.next = next === undefined ? null : next;
}

function TreeNode(val, left, right) {
    this.val = val === undefined ? 0 : val;
    this.left = left === undefined ? null : left;
    this.right = right === undefined ? null : right;
}

var sortedListToBST = function(head) {
    return dfs(head)
};

var dfs = function (head) {
    if (!head)
        return null
    var slow = head, fast = head, pre = new ListNode(0, head)
    while (fast && fast.next) {
        fast = fast.next.next
        slow = slow.next
        pre = pre.next
    }
    var root = new TreeNode(slow.val)
    pre.next = null
    var leftHead = slow == head ? null : head
    var rightHead = slow.next
    root.left = dfs(leftHead)
    root.right = dfs(rightHead)
    return root
}