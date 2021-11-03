function TreeNode(val, left, right) {
    this.val = (val === undefined ? 0 : val)
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}

/**
 * @param {TreeNode} root
 * @return {number}
 */
var sumNumbers = function (root) {
    let sum = 0;
    var dfs = function (root, num) {
        if (root == null)
            return;
        if (root.left == root.right)
            sum += num * 10 + root.val;
        dfs(root.left, num * 10 + root.val);
        dfs(root.right, num * 10 + root.val);
    }
    dfs(root, 0);
    return sum;
};