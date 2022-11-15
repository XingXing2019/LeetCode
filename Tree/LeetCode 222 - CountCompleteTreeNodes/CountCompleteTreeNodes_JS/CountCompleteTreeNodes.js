function TreeNode(val, left, right) {
    this.val = (val===undefined ? 0 : val)
    this.left = (left===undefined ? null : left)
    this.right = (right===undefined ? null : right)
}

var countNodes = function (root) {
    if (!root) return 0
    var res = 0
    var queue = [root]
    while (queue.length != 0) {
        var count = queue.length
        res += count
        for (let i = 0; i < count; i++) {
            var cur = queue.shift()
            if (cur.left) queue.push(cur.left)
            if (cur.right) queue.push(cur.right)
        }
    }
    return res
};