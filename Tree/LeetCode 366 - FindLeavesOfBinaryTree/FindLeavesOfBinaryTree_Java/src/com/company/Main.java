package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

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
        TreeNode a = new TreeNode(1);
        TreeNode b = new TreeNode(2);
        TreeNode c = new TreeNode(3);
        TreeNode d = new TreeNode(4);
        TreeNode e = new TreeNode(5);

        a.left = b;
        a.right = c;
        b.left = d;
        b.right = e;

        findLeaves(a);
    }
    static List<List<Integer>> res;
    public static List<List<Integer>> findLeaves(TreeNode root) {
        res = new ArrayList<>();
        dfs(root);
        return res;
    }

    public static int dfs(TreeNode node) {
        if (node == null) return  -1;
        int left = dfs(node.left);
        int right = dfs(node.right);
        int height = Math.max(left, right) + 1;
        if(height == res.size()) res.add(new ArrayList<>());
        res.get(height).add(node.val);
        return height;
    }
}
