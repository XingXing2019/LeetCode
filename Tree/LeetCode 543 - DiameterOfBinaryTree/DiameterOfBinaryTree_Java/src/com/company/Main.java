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

    int max = 0;
    public int diameterOfBinaryTree(TreeNode root) {
        maxDepth(root);
        return max;
    }

    public int maxDepth(TreeNode node){
        if (node == null) return 0;
        int left = maxDepth(node.left);
        int right = maxDepth(node.right);
        max = Math.max(max, left + right);
        return Math.max(left, right) + 1;
    }
}
