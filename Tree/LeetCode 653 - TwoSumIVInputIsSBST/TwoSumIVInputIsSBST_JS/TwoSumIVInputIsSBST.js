function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

/**
 * @param {TreeNode} root
 * @param {number} k
 * @return {boolean}
 */
var findTarget = function (root, k) {
    var set = new Set()
    var dfs = function (node) {
        if (!node) return false
        if (set.has(k - node.val))
            return true
        set.add(node.val)
        return dfs(node.left) || dfs(node.right)
    }
    return dfs(root)
}
