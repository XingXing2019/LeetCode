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

    public boolean hasPathSum(TreeNode root, int targetSum) {
        return dfs(root, 0, targetSum);
    }

    public boolean dfs(TreeNode node, int path, int targetSum){
        if(node == null) return false;
        if(node.left == node.right && path + node.val == targetSum) return true;
        return dfs(node.left, path + node.val, targetSum) || dfs(node.right, path + node.val, targetSum);
    }
}
