function Node(val, left, right, next) {
    this.val = val === undefined ? null : val;
    this.left = left === undefined ? null : left;
    this.right = right === undefined ? null : right;
    this.next = next === undefined ? null : next;
};

/**
 * @param {Node} root
 * @return {Node}
 */
var connect = function (root) {
    if (!root) return root;
    var queue = [];
    queue.push(root);
    while (queue.length != 0) {
        var count = queue.length;
        for (let i = 0; i < count; i++) {
            var cur = queue.shift();
            cur.next = i == count - 1 ? null : queue[0];
            if (cur.left) queue.push(cur.left);
            if (cur.right) queue.push(cur.right);
        }
    }
    return root;
};