function TreeNode(val, left, right) {
    this.val = (val === undefined ? 0 : val)
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}

/**
 * @param {TreeNode} root
 * @return {TreeNode}
 */
var invertTree = function (root) {
    if (root === null)
        return root;
    let left = invertTree(root.right);
    let right = invertTree(root.left);
    root.left = left;
    root.right = right;
    return root;
};