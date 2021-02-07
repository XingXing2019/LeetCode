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

    }

    double gap = Double.MAX_VALUE;
    int res;
    public int closestValue(TreeNode root, double target) {
        if(root == null) return Integer.MAX_VALUE;
        if(Math.abs(root.val - target) < gap){
            gap = Math.abs(root.val - target);
            res = root.val;
        }
        if(root.val > target) closestValue(root.left, target);
        else closestValue(root.right, target);
        return res;
    }
}
