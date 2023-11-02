package com.company;

public class Main {

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

    public static void main(String[] args) {
	// write your code here
    }

    int res;
    public int averageOfSubtree(TreeNode root) {
        dfs(root);
        return res;
    }

    private int[] dfs(TreeNode node) {
        if (node == null)
            return new int[2];
        var val = node.val;
        var count = 1;
        var left = dfs(node.left);
        var right = dfs(node.right);
        val += left[0] + right[0];
        count += left[1] + right[1];
        if (val / count == node.val)
            res++;
        return new int[]{val, count};
    }
}
