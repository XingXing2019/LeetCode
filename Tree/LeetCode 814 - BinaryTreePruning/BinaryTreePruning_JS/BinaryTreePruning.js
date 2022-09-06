function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

var pruneTree = function (root) {
    var dfs = function (node, parent) {
        if (!node) return false
        var isOne = node.val == 1
        var left = dfs(node.left, node)
        var right = dfs(node.right, node)
        if (!isOne && !left && !right && parent) {
            if (node == parent.left)
                parent.left = null
            else
                parent.right = null
        } 
        return isOne || left || right
    }
    dfs(root, null)
    if (!root.left && !root.right && root.val == 0)
        return null
    return root
}

var pruneTree = function (root) {
    var hasOne = function (node) {
        if (!node) return false
        return node.val == 1 || hasOne(node.left) || hasOne(node.right)
    }
    if (!hasOne(root)) return null
    root.left = pruneTree(root.left)
    root.right = pruneTree(root.right)
    return root
}