 function TreeNode(val, left, right) {
     this.val = (val === undefined ? 0 : val)
     this.left = (left === undefined ? null : left)
     this.right = (right === undefined ? null : right)
 }

 /**
  * @param {TreeNode} root
  * @return {number}
  */
 var sumOfLeftLeaves = function (root) {
     let res = 0;
     dfs = function (root, parent) {
         if (root == null)
             return;
         if (root.left == root.right && parent != null && root == parent.left)
             res += root.val;
         dfs(root.left, root);
         dfs(root.right, root);
     };
     dfs(root, null);
     return res;
 };