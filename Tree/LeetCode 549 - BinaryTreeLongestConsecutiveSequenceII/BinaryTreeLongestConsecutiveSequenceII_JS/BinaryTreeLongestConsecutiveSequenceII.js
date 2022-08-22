function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}
/**
 * @param {TreeNode} root
 * @return {number}
 */
var longestConsecutive = function (root) {
    var res = 0
    var dfs = function (node) {
        if (!node)
            return [0, 0]        
        var increase = 1, decrease = 1
        if (node.left) {
            var left = dfs(node.left)
            if (node.left.val == node.val + 1)
                decrease = Math.max(decrease, left[1] + 1)
            if (node.left.val == node.val - 1)
                increase = Math.max(increase, left[0] + 1)
        }
        if (node.right) {
            var right = dfs(node.right)
            if (node.right.val == node.val - 1)
                increase = Math.max(increase, right[0] + 1)
            if (node.right.val == node.val + 1)
                decrease = Math.max(decrease, right[1] + 1)
        }
        res = Math.max(res, increase + decrease - 1)
        return [increase, decrease]
    }
    dfs(root)
    return res
}
