function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

var longestConsecutive = function (root) {
    var max = 0
    var dfs = function (node, parent, len) {
        if (!node) return
        len = !parent || node.val != parent.val + 1 ? 1 : len + 1
        max = Math.max(max, len + 1)
        dfs(node.left, node, len)
        dfs(node.right, node, len)
    }
    dfs(root, null, 0)
    return max - 1
}
