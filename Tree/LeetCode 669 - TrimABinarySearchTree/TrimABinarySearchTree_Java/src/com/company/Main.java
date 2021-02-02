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
	    TreeNode a = new TreeNode(3);
	    TreeNode b = new TreeNode(1);
	    TreeNode c = new TreeNode(4);
	    TreeNode d = new TreeNode(2);

	    a.left = b;
	    a.right = c;
	    b.right = d;

	    int low = 3, high = 4;
	    trimBST(a, low, high);
    }
    public static TreeNode trimBST(TreeNode root, int low, int high) {
        if(root == null) return null;
        if(root.val < low) return trimBST(root.right, low, high);
        else if (root.val > high) return trimBST(root.left, low, high);
        root.left = trimBST(root.left, low, high);
        root.right = trimBST(root.right, low, high);
        return root;
    }
}
