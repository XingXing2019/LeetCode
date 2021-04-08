package com.company;

class TreeNode {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode(int x) { val = x; }
  }

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public TreeNode inorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode res = new TreeNode(Integer.MAX_VALUE);
        TreeNode point = p.right;
        while (point != null && point.left != null)
            point = point.left;
        if(point != null) res = point;
        while (root != p){
            if(root.val > p.val && root.val < res.val)
                res = root;
            if(p.val > root.val)
                root = root.right;
            else
                root = root.left;
        }
        return res.val == Integer.MAX_VALUE ? null : res;
    }
}
