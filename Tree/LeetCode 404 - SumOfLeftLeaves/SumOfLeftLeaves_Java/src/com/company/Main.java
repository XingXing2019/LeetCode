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

    int sum;
    public int sumOfLeftLeaves(TreeNode root) {
        dfs(root, null);
        return sum;
    }

    public void dfs(TreeNode node, TreeNode parent){
        if(node == null) return;
        if(node.left == node.right && parent != null && node == parent.left) sum += node.val;
        dfs(node.left, node);
        dfs(node.right, node);
    }
}
