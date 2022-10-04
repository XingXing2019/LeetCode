function TreeNode(val, left, right) {
    this.val = (val===undefined ? 0 : val)
    this.left = (left===undefined ? null : left)
    this.right = (right===undefined ? null : right)
}

var hasPathSum = function(root, targetSum) {
    var dfs = function (node, target) {
        if (!node) return false
        if (node.left == node.right && target == node.val)
            return true
        return dfs(node.left, target - node.val) || dfs(node.right, target - node.val)
    }
    return dfs(root, targetSum)
}