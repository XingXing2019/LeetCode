function TreeNode(val, left, right) {
    this.val = (val===undefined ? 0 : val)
    this.left = (left===undefined ? null : left)
    this.right = (right===undefined ? null : right)
}

var maxPathSum = function(root) {
    var res = -Number.MAX_VALUE;    
    var dfs = function (node) {
        if (!node) return 0
        var left = Math.max(0, dfs(node.left))
        var right = Math.max(0, dfs(node.right))
        res = Math.max(res, left + node.val + right)
        return node.val + Math.max(left, right)
    }
    dfs(root)
    return res
};

