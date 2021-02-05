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
    int min;
    int pre;
    public int getMinimumDifference(TreeNode root) {
        min = Integer.MAX_VALUE;
        pre = -1;
        dfs(root);
        return min;
    }
    public void dfs(TreeNode node){
        if(node == null) return;
        dfs(node.left);
        if(pre != -1)
            min = Math.min(min, Math.abs(pre - node.val));
        pre = node.val;
        dfs(node.right);
    }
}
