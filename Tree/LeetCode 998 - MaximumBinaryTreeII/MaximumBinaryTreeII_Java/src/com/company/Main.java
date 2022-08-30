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

    public TreeNode insertIntoMaxTree(TreeNode root, int val) {
        if (root == null || val > root.val)
            return new TreeNode(val, root, null);
        root.right = insertIntoMaxTree(root.right, val);
        return root;
    }
}
