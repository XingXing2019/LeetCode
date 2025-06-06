package com.company;

import java.util.ArrayDeque;

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

    public int findSecondMinimumValue_bfs(TreeNode root) {
        if (root == null || root.left == null) return -1;
        ArrayDeque<TreeNode> queue = new ArrayDeque<>() {{
            offer(root);
        }};
        boolean hasMax = false;
        int min = Integer.MAX_VALUE, secondMin = Integer.MAX_VALUE;
        while (!queue.isEmpty()) {
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                if (cur.val == Integer.MAX_VALUE) hasMax = true;
                if (cur.val < min) {
                    secondMin = min;
                    min = cur.val;
                } else if (cur.val != min && cur.val < secondMin) secondMin = cur.val;
                if (cur.left != null) {
                    queue.offer(cur.left);
                    queue.offer(cur.right);
                }
            }
        }
        if (hasMax) return secondMin;
        return secondMin == Integer.MAX_VALUE ? -1 : secondMin;
    }

    int min = Integer.MAX_VALUE;
    int secondMin = Integer.MAX_VALUE;
    boolean hasNax;
    public int findSecondMinimumValue_dfs(TreeNode root) {
        dfs(root);
        if(hasNax) return secondMin;
        return secondMin == Integer.MAX_VALUE ? -1 : secondMin;
    }

    public void dfs(TreeNode node) {
        if (node == null) return;
        if (node.val == Integer.MAX_VALUE) hasNax = true;
        if (node.val < min) {
            secondMin = min;
            min = node.val;
        } else if (node.val != min && node.val < secondMin)
            secondMin = node.val;
        dfs(node.left);
        dfs(node.right);
    }
}
