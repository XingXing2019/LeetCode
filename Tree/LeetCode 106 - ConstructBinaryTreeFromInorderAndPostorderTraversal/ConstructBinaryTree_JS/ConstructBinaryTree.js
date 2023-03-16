function TreeNode(val, left, right) {
    this.val = val === undefined ? 0 : val
    this.left = left === undefined ? null : left
    this.right = right === undefined ? null : right
}

var buildTree = function(inorder, postorder) {
    if (inorder.length == 0) return null
    var val = postorder[postorder.length - 1]
    var index = inorder.indexOf(val)
    var root = new TreeNode(val)
    root.left = buildTree(inorder.slice(0, index), postorder.slice(0, index))
    root.right = buildTree(inorder.slice(index + 1), postorder.slice(index, postorder.length - 1))
    return root
}