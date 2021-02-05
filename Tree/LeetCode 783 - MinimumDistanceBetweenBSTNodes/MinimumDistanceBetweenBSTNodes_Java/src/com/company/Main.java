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
    int min = Integer.MAX_VALUE;
    int pre = -1;
    public int minDiffInBST(TreeNode root) {
        dfs(root);
        return min;
    }
    public void dfs(TreeNode root){
        if(root == null) return;
        dfs(root.left);
        if(pre != -1) min = Math.min(min, Math.abs(pre - root.val));
        pre  = root.val;
        dfs(root.right);
    }
}
