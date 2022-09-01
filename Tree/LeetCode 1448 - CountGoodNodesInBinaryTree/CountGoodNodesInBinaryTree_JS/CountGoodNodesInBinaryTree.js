function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

var goodNodes = function (root) {
    var count = 0
    var dfs = function (root, max) {
        if (!root) return
        if (root.val >= max)
            count++;
        dfs(root.left, Math.max(max, root.val))
        dfs(root.right, Math.max(max, root.val))
    }
    dfs(root, -Number.MAX_VALUE)
    return count
}
