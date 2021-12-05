function TreeNode(val, left, right) {
    this.val = (val === undefined ? 0 : val)
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}
/**
 * @param {TreeNode} root
 * @return {number}
 */

var rob = function (root) {
    var map = new Map();
    var dfs = function (root) {
        if (root === null) return 0;
        if (map.has(root)) return map.get(root);
        var enter = root.val;
        if (root.left != null)
            enter += dfs(root.left.left) + dfs(root.left.right);
        if (root.right != null)
            enter += dfs(root.right.left) + dfs(root.right.right);
        var notEnter = dfs(root.left) + dfs(root.right);
        var max = Math.max(enter, notEnter);
        map.set(root, max);
        return max;
    }
    return dfs(root);
};