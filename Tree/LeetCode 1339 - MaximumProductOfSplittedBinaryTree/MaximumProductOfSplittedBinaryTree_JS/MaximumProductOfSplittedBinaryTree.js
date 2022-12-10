function TreeNode(val, left, right) {
    this.val = (val === undefined ? 0 : val) \
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}

var maxProduct = function(root) {
    var res = 0, mod = 1_000_000_000 + 7
    var map = new Map()
    var total = getSum(root, map)
    var dfs = function (root) {
        if (!root) return
        res = Math.max(res, map.get(root) * (total - map.get(root)))
        dfs(root.left)
        dfs(root.right)
    }
    dfs(root)
    return res % mod
}

var getSum = function (root, map) {
    if (!root) return 0;
    var sum = root.val
    sum += getSum(root.left, map)
    sum += getSum(root.right, map)
    map.set(root, sum)
    return sum
}