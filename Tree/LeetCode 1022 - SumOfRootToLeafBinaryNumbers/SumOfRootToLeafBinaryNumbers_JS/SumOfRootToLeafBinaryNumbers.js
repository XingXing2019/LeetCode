function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}
/**
 * @param {TreeNode} root
 * @return {number}
 */
var sumRootToLeaf = function (root) {
    var res = 0
    var dfs = function (node, sum) {
        if (!node) return
        if (!node.left && !node.right)
            res += sum * 2 + node.val
        dfs(node.left, sum * 2 + node.val)
        dfs(node.right, sum * 2 + node.val)
    }
    dfs(root, 0)
    return res
}
