function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

var longestUnivaluePath = function (root) {
    var max = 0
    var dfs = function (node) {
        if (!node) return 0
        var left = dfs(node.left)
        var right = dfs(node.right)
        var leftPath = node.left && node.val == node.left.val ? left + 1 : 0
        var rightPath = node.right && node.val == node.right.val ? right + 1 : 0
        max = Math.max(max, leftPath + rightPath)
        return Math.max(leftPath, rightPath)
    }
    dfs(root)
    return max
}
