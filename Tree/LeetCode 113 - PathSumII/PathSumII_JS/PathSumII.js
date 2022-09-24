function TreeNode (val, left, right) {
    this.val = (val === undefined ? 0 : val)
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}

var pathSum = function(root, targetSum) {
    var dfs = function (node, path, target, res) {
        if (!node) return
        if (node.left == node.right && target - node.val == 0)
            res.push([...path, node.val])
        path.push(node.val)
        dfs(node.left, path, target - node.val, res)
        dfs(node.right, path, target - node.val, res)
        path.pop()
    }
    var res = []
    dfs(root, [], targetSum, res)
    return res
}