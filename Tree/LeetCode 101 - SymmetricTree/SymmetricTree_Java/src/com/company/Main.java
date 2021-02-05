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

    public boolean isSymmetric(TreeNode root) {
        if(root == null) return true;
        return isMirror(root.left, root.right);
    }

    public boolean isMirror(TreeNode p, TreeNode q){
        if(p == q) return true;
        if(p == null || q == null) return false;
        return p.val == q.val && isMirror(p.left, q.right) && isMirror(p.right, q.left);
    }
}
