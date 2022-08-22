function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

var printTree = function (root) {
    var getHeight = function (node) {
        if (!node) return 0;
        return Math.max(getHeight(node.left), getHeight(node.right)) + 1
    }

    var dfs = function (node, li, hi, height, matrix) {
        if (!node) return
        var index = li + ~~((hi - li) / 2)
        matrix[height][index] = node.val + ''
        dfs(node.left, li, index - 1, height + 1, matrix)
        dfs(node.right, index + 1, hi, height + 1, matrix)
    }

    var height = getHeight(root)
    var matrix = []
    var width = Math.pow(2, height) - 1
    for (let i = 0; i < height; i++)
        matrix.push(new Array(width).fill(''))
    dfs(root, 0, width - 1, 0, matrix)
    return matrix
}
