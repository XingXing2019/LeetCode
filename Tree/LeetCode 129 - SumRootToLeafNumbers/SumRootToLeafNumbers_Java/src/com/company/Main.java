package com.company;

class TreeNode {
    int val;
    TreeNode left;
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

    int sum = 0;

    public int sumNumbers(TreeNode root) {
        dfs(root, 0);
        return sum;
    }

    public void dfs(TreeNode node, int num) {
        if (node == null) return;
        if (node.left == node.right) sum += num + node.val;
        dfs(node.left, (num + node.val) * 10);
        dfs(node.right, (num + node.val) * 10);
    }
}
