function TreeNode(val, left, right) {
    this.val = val === undefined ? 0 : val;
    this.left = left === undefined ? null : left;
    this.right = right === undefined ? null : right;
}

var isSymmetric = function (root) {
    var isMirror = function (p, q) {
        if (!p && !q) return true
        if (!p || !q || p.val != q.val) return false
        return isMirror(p.left, q.right) && isMirror(p.right, q.left)
    }
    if (!root) return true;
    return isMirror(root.left, root.right)
}
