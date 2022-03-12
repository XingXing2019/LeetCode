function Node(val, children) {
  this.val = val
  this.children = children
}

/**
 * @param {Node|null} root
 * @return {number[]}
 */
var postorder = function (root) {
    var res = []
    var dfs = function (node) {
        if (!node) return
        for (let i = 0; i < node.children.length; i++) 
            dfs(node.children[i])
        res.push(node.val)
    }
    dfs(root)
    return res
}
