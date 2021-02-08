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
    public int sumEvenGrandparent(TreeNode root) {
        dfs(root);
        return sum;
    }

    public void dfs(TreeNode node){
        if(node == null) return;
        if(node.val % 2 == 0){
            if(node.left != null && node.left.left != null) sum += node.left.left.val;
            if(node.left != null && node.left.right != null) sum += node.left.right.val;
            if(node.right != null && node.right.left != null) sum += node.right.left.val;
            if(node.right != null && node.right.right != null) sum += node.right.right.val;
        }
        dfs(node.left);
        dfs(node.right);
    }
}
