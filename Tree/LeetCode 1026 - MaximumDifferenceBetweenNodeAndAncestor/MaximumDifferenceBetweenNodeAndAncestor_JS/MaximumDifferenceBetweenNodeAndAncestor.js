function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}
/**
 * @param {TreeNode} root
 * @return {number}
 */
var maxAncestorDiff = function (root) {
    var res = 0;
    var dfs = function (node, min, max) {
        if (!node) return
        res = Math.max(res, Math.max(Math.abs(node.val - max), Math.abs(node.val - min)))
        dfs(node.left, Math.min(min, node.val), Math.max(max, node.val))
        dfs(node.right, Math.min(min, node.val), Math.max(max, node.val))
    }
    dfs(root, root.val, root.val)
    return res
}
