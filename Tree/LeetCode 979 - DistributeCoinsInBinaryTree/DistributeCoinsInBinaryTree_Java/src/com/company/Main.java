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
    public int distributeCoins(TreeNode root) {
        dfs(root, null);
        return res;
    }
    public void dfs(TreeNode child, TreeNode parent){
        if(child == null) return;
        dfs(child.left, child);
        dfs(child.right, child);
        if(parent != null)
            parent.val += child.val - 1;
        res += Math.abs(child.val - 1);
    }
}
