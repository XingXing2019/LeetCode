function TreeNode(val, left, right) {
    this.val = (val === undefined ? 0 : val)
    this.left = (left === undefined ? null : left)
    this.right = (right === undefined ? null : right)
}
/**
 * @param {TreeNode} root
 * @param {number} low
 * @param {number} high
 * @return {number}
 */
var rangeSumBST = function (root, low, high) {
    if (!root) return 0;
    var res = 0
    if (low <= root.val && root.val <= high)
        res += root.val;
    if (root.val >= low)
        res += rangeSumBST(root.left, low, high);
    if (root.val <= high)
        res += rangeSumBST(root.right, low, high);
    return res;
};