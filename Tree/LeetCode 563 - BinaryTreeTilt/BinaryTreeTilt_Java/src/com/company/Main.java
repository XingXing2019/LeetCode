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

    int res = 0;
    public int findTilt(TreeNode root) {
        getSum(root);
        return res;
    }
    public int getSum(TreeNode node){
        if(node == null) return 0;
        int left = getSum(node.left);
        int right = getSum(node.right);
        res += Math.abs(left - right);
        return left + right + node.val;
    }
}
