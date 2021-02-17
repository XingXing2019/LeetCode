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
	    TreeNode a = new TreeNode(2);
	    TreeNode b = new TreeNode(1);
	    TreeNode c = new TreeNode(1);
	    TreeNode d = new TreeNode(1);
	    TreeNode e = new TreeNode(3);
	    TreeNode f = new TreeNode(1);
	    a.left = b;
	    a.right = c;
	    b.left = d;
	    b.right = e;
	    e.right = f;

        pseudoPalindromicPaths(a);
    }
    static int res;
    static int[] count;
    public static int pseudoPalindromicPaths (TreeNode root) {
        count = new int[10];
        dfs(root);
        return res;
    }
    public static void dfs(TreeNode node){
        if(node == null) return;
        count[node.val]++;
        if(node.left == node.right){
            int countOdd = 0;
            for (int num : count)
                countOdd += num % 2 == 0 ? 0 : 1;
            if(countOdd < 2) res++;
        }
        dfs(node.left);
        dfs(node.right);
        count[node.val]--;
    }
}
