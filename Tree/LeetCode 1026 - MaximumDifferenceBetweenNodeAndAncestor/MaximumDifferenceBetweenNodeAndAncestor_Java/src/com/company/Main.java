package com.company;

public class TreeNode {
    TreeNode left;
    int val;
    TreeNode right;

    TreeNode() {
    }

    TreeNode(int val) {
        this.val = val;
    }

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

    int res;
    public int maxAncestorDiff(TreeNode root) {
        dfs(root, root.val, root.val);
        return res;
    }

    public void dfs(TreeNode root, int max, int min) {
        if (root == null)
            return;
        res = Math.max(res, Math.max(Math.abs(root.val - max), Math.abs(root.val - min)));
        dfs(root.left, Math.max(max, root.val), Math.min(min, root.val));
        dfs(root.right, Math.max(max, root.val), Math.min(min, root.val));
    }
}
