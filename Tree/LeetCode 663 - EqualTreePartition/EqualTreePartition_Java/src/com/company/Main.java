package com.company;

class TreeNode {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode() {}
      TreeNode(int val) { this.val = val; }
      TreeNode(int val, TreeNode left, TreeNode right) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean checkEqualTree(TreeNode root) {
        dfs(root);
        return check(root, root.val);
    }

    public int dfs(TreeNode root) {
        if (root == null) return 0;
        root.val += dfs(root.left);
        root.val += dfs(root.right);
        return root.val;
    }

    public boolean check(TreeNode root, int rootVal){
        if(root == null) return false;
        if(root.left != null && rootVal == 2 * root.left.val)
            return true;
        if(root.right != null && rootVal == 2 * root.right.val)
            return true;
        return check(root.left, rootVal) || check(root.right, rootVal);
    }
}
