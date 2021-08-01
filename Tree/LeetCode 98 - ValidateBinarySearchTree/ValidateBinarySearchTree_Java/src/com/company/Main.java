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
	    var a = new TreeNode(2);
	    var b = new TreeNode(1);
	    var c = new TreeNode(3);

	    a.left = b;
	    a.right = c;

        System.out.println(isValidBST(a));
    }

    public static boolean isValidBST(TreeNode root) {
        return dfs(root, Long.MAX_VALUE, Long.MIN_VALUE);
    }

    private static boolean dfs(TreeNode node, long min, long max){
        if(node == null) return true;
        if(node.val >= min || node.val <= max) return false;
        return dfs(node.left, node.val, max) && dfs(node.right, min, node.val);
    }
}
