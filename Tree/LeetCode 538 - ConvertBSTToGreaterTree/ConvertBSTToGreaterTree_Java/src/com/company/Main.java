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

    int sum = 0;
    public TreeNode convertBST(TreeNode root) {
        if (root == null) return null;
        root.right = convertBST(root.right);
        sum += root.val;
        root.val = sum;
        root.left = convertBST(root.left);
        return root;
    }
}
