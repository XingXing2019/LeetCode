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
 * @return {number[][]}
 */
var zigzagLevelOrder = function (root) {
    var res = []
    var dfs = function (node, level) {
        if (!node) return
        if (res.length <= level)
            res.push([])
        if (level % 2 == 0)
            res[level].push(node.val)
        else
            res[level].unshift(node.val)
        dfs(node.left, level + 1)
        dfs(node.right, level + 1)
    }
    dfs(root, 0)
    return res
}