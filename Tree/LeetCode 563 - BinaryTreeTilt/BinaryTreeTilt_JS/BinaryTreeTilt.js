function TreeNode(val, left, right) {
    this.val = (val === undefined ? 0 : val)
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}
/**
 * @param {TreeNode} root
 * @return {number}
 */
var findTilt = function (root) {
    var res = 0;
    var dfs = function(node) {
        if (!node) return 0;
        var left = dfs(node.left);
        var right = dfs(node.right);
        res += Math.abs(left - right);
        return left + right + node.val;
    };
    dfs(root);
    return res;
};

