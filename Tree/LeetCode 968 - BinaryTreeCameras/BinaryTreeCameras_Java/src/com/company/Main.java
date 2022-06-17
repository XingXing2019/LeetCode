package com.company;

import java.util.HashSet;

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

    int res;
    public int minCameraCover(TreeNode root) {
        HashSet<TreeNode> covered = new HashSet<>();
        covered.add(null);
        dfs(root, null, covered);
        return res;
    }

    public void dfs(TreeNode cur, TreeNode parent, HashSet<TreeNode> covered) {
        if (cur == null)
            return;
        dfs(cur.left, cur, covered);
        dfs(cur.right, cur, covered);
        if (parent == null && !covered.contains(cur) || !covered.contains(cur.left) || !covered.contains(cur.right)) {
            res++;
            covered.add(cur);
            covered.add(parent);
            covered.add(cur.left);
            covered.add(cur.right);
        }
    }
}
