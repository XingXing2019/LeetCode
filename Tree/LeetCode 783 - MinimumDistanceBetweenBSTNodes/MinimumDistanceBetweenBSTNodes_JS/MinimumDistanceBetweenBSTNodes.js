/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number}
 */
var minDiffInBST = function(root) {
    var last = -100001, res = Number.MAX_VALUE
    var dfs = function (node) {
        if (!node) return
        dfs(node.left)
        res = Math.min(res, node.val - last)
        last = node.val
        dfs(node.right)
    }
    dfs(root)
    return res
}