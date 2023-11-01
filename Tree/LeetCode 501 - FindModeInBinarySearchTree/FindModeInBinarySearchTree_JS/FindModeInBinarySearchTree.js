function TreeNode(val, left, right) {
     this.val = (val===undefined ? 0 : val)
     this.left = (left===undefined ? null : left)
     this.right = (right===undefined ? null : right)
}
 
/**
 * @param {TreeNode} root
 * @return {number[]}
 */
var findMode = function(root) {
    var max = 0    
    var dfs = function (node, map) {
        if (!node) return
        if (!map[node.val])
            map[node.val] = 0
        map[node.val] = map[node.val] + 1
        max = Math.max(max, map[node.val])
        dfs(node.left, map)
        dfs(node.right, map)
    }
    var map = {}
    dfs(root, map)
    return Object.keys(map).filter(x => map[x] == max)
};

