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
    boolean found;
    int count;
    int res;
    public int kthSmallest(TreeNode root, int k) {
        dfs(root, k);
        return res;
    }
    public void dfs(TreeNode node, int k){
        if(node == null || found) return;
        dfs(node.left, k);
        if(++count == k){
            res = node.val;
            found = true;
        }
        dfs(node.right, k);
    }
}
