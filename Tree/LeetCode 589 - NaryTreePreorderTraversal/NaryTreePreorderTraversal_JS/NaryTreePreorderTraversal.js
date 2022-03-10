function Node(val, children) {
  this.val = val
  this.children = children
}

/**
 * @param {Node|null} root
 * @return {number[]}
 */
var preorder = function (root) {
    var res = []
    var dfs = function (node) {
        if (!node) return
        res.push(node.val)
        for (let i = 0; i < node.children.length; i++) 
            dfs(node.children[i])
    }
    dfs(root)
    return res
}
