function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

/**
 * @param {TreeNode} root1
 * @param {TreeNode} root2
 * @return {number[]}
 */
var getAllElements = function (root1, root2) {
    var dfs = function (node, vals) {
        if (!node) return
        dfs(node.left, vals)
        vals.push(node.val)
        dfs(node.right, vals)
    }
    var vals1 = [], vals2 = []
    dfs(root1, vals1)
    dfs(root2, vals2)
    var p1 = 0, p2 = 0
    var res = []
    while (p1 < vals1.length && p2 < vals2.length)
        res.push(vals1[p1] < vals2[p2] ? vals1[p1++] : vals2[p2++])
    while (p1 < vals1.length)
        res.push(vals1[p1++])
    while (p2 < vals2.length)
        res.push(vals2[p2++])
    return res
}
