function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

var deepestLeavesSum = function(root) {
    var queue = [];
    queue.push(root);
    var res = 0;
    while (queue.length != 0) {
        var count = queue.length;
        var sum = 0;
        for (let i = 0; i < count; i++) {
            var cur = queue.shift();
            sum += cur.val;
            if (cur.left) queue.push(cur.left);
            if (cur.right) queue.push(cur.right);
        }
        res = sum;
    }
    return res;
};