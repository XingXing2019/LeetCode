function TreeNode(val, left, right) {
  this.val = val === undefined ? 0 : val
  this.left = left === undefined ? null : left
  this.right = right === undefined ? null : right
}

var findLeaves = function (root) {
    var dfs = function (root, res) {
        if (!root)
            return 0;
        var left = dfs(root.left, res);
        var right = dfs(root.right, res);
        var height = Math.max(left, right) + 1;
        if (res.length < height)
            res.push([]);
        res[height - 1].push(root.val);
        return height;
    }
    var res = [];
    dfs(root, res);
    return res;
}
