function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

var findDuplicateSubtrees = function (root) { 
    var map = new Map()
    var dfs = function (node) {
        if (!node) return ''
        var key = `${node.val}-${dfs(node.left)}-${dfs(node.right)}`
        if (!map.has(key))
            map.set(key, [])
        map.get(key).push(node)
        return key
    }
    dfs(root)
    var res = []
    map.forEach((value, key) => {
      if (value.length > 1) res.push(value[0])  
    })
    return res
}

