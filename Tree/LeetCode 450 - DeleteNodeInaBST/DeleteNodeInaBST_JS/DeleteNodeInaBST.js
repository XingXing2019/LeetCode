function TreeNode(val, left, right) {
    this.val = (val === undefined ? 0 : val)
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}

/**
 * @param {TreeNode} root
 * @param {number} key
 * @return {TreeNode}
 */
var deleteNode = function (root, key) {
    if (root == null) return null;
    if (root.val == key) {
        if (root.left == null && root.right == null)
            return null;
        else if (root.left == null && root.right != null)
            return root.right;
        else if (root.left != null && root.right == null)
            return root.left;
        else {
            var smallest = findSamllest(root.right);
            root.val = smallest.val;
            root.right = deleteNode(root.right, smallest.val);
        }
    } else if (root.val < key)
        root.right = deleteNode(root.right, key);
    else
        root.left = deleteNode(root.left, key);
    return root;
};

var findSamllest = function(root) {
    while (root.left != null)
        root = root.left;
    return root;
}