function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}
/**
 * @param {TreeNode} root
 * @param {number} val
 * @return {TreeNode}
 */
var insertIntoBST = function (root, val) {
    if (!root) return new TreeNode(val)
    if (val < root.val)
        root.left = insertIntoBST(root.left, val)
    else
        root.right = insertIntoBST(root.right, val)
    return root
}
