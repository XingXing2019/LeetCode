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

    int res;
    public int goodNodes(TreeNode root) {
        dfs(root, Integer.MIN_VALUE);
        return res;
    }

    public void dfs(TreeNode node, int max){
        if(node == null) return;
        max = Math.max(max, node.val);
        dfs(node.left, max);
        dfs(node.right, max);
        if(node.val >= max) res++;
    }
}
