function TreeNode (val, left, right) {
    this.val = (val === undefined ? 0 : val)
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}

var addOneRow = function (root, val, depth) {
    if (depth == 1)
        return new TreeNode(val, root, null)
    var queue = []
    queue.push(root)
    while (queue.length != 0) {
        depth--
        var count = queue.length
        for (let i = 0; i < count; i++) {
            var cur = queue.shift()
            if (depth == 1) {
                cur.left = new TreeNode(val, cur.left, null)
                cur.right = new TreeNode(val, null, cur.right)
            }
            if (cur.left) queue.push(cur.left)
            if (cur.right) queue.push(cur.right)
        }
        if (depth == 1)
            return root
    }
    return root
}