package com.company;

public class TreeNode {
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
    public int sumRootToLeaf(TreeNode root) {
        dfs(root, 0);
        return sum;
    }

    public void dfs(TreeNode root, int num){
        if (root == null) return;
        if(root.left == root.right) sum += num * 2 + root.val;
        dfs(root.left, num * 2 + root.val);
        dfs(root.right, num * 2 + root.val);
    }
}
