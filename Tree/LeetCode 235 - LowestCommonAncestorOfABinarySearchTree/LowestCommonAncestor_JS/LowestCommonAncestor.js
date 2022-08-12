function TreeNode(val) {
  this.val = val
  this.left = this.right = null
}

var lowestCommonAncestor = function (root, p, q) {    
    var dfs = function (node, target, ancestors) {
        if (!node || found)
            return;
        if (node == target)
            found = true;
        dfs(node.left, target, ancestors);
        dfs(node.right, target, ancestors);
        if (found) ancestors.push(node);
    };
    var pAncestors = [];
    var qAncestors = [];
    var found = false;
    dfs(root, p, pAncestors);
    found = false;
    dfs(root, q, qAncestors);
    while (pAncestors.length > qAncestors.length)
        pAncestors.shift();
    while (qAncestors.length > pAncestors.length)
        qAncestors.shift();
    while (pAncestors[0] != qAncestors[0]) {
        pAncestors.shift();
        qAncestors.shift();
    }
    return pAncestors[0];
}


