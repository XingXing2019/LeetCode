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
    public TreeNode pruneTree(TreeNode root) {
        return !containsOne(root) ? null : root;
    }
    public boolean containsOne(TreeNode node){
        if(node == null) return false;
        boolean left = containsOne(node.left);
        boolean right = containsOne(node.right);
        if(!left) node.left = null;
        if(!right) node.right = null;
        return node.val == 1 || left || right;
    }
}
