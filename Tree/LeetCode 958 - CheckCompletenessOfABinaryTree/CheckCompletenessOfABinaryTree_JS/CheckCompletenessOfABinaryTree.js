function TreeNode(val, left, right) {
    this.val = val === undefined ? 0 : val
    this.left = left === undefined ? null : left
    this.right = right === undefined ? null : right
}

var isCompleteTree = function (root) {
    var level = dfs(root), expected = 1
    var queue = []
    queue.push(root)
    while (queue.length != 0) {
        var count = queue.length
        var nodes = []
        for (let i = 0; i < count; i++) {
            var cur = queue.shift()
            nodes.push(cur.left, cur.right)
            if (cur.left) queue.push(cur.left)
            if (cur.right) queue.push(cur.right)
        }
        for (let i = 1; i < nodes.length; i++) {
            if (nodes[i] && !nodes[i - 1]) return false
        }
        if (level != 1 && count != expected) return false
        expected *= 2
        level--
    }
    return true;
}

var dfs = function (node) {
    return !node ? 0 : Math.max(dfs(node.left), dfs(node.right)) + 1
}
