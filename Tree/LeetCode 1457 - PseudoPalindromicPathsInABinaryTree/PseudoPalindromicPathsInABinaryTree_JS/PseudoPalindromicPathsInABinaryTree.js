function TreeNode(val, left, right) {
    this.val = (val===undefined ? 0 : val)
    this.left = (left===undefined ? null : left)
    this.right = (right===undefined ? null : right)
}

var pseudoPalindromicPaths = function (root) {
    var res = 0
    var dfs = function (node, freq) {
        if (!node) return
        freq[node.val]++
        if (node.left === node.right) {
            var count = 0;
            for (let i = 0; i < freq.length; i++)
                count += freq[i] % 2 != 0 ? 1 : 0
            if (count < 2)
                res++
        }
        dfs(node.left, freq)
        dfs(node.right, freq)
        freq[node.val]--
    }
    var freq = new Array(10).fill(0)
    dfs(root, freq)
    return res
}