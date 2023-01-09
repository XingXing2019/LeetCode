function TreeNode(val, left, right) {
    this.val = (val===undefined ? 0 : val)
    this.left = (left===undefined ? null : left)
    this.right = (right===undefined ? null : right)
}
/**
 * @param {TreeNode} root
 * @return {number[]}
 */
var preorderTraversal = function(root) {
    var dfs = function (node, res) {
        if (!node) return
        res.push(node.val)
        dfs(node.left, res)
        dfs(node.right, res)
    }
    var res = []
    dfs(root, res)
    return res
};