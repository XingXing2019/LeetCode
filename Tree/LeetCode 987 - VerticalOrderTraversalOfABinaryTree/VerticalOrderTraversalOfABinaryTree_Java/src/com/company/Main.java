package com.company;

import java.util.*;

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    TreeNode() { }
    TreeNode(int val) { this.val = val; }
    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Main {

    public static void main(String[] args) {
        TreeNode a = new TreeNode(0);
        TreeNode b = new TreeNode(1);
        TreeNode c = new TreeNode(2);

        a.right = b;
        b.left = c;

        System.out.println(verticalTraversal(a));
    }

    static class Node {
        int val;
        int row;
        int col;
        public Node(int val, int row, int col) {
            this.val = val;
            this.row = row;
            this.col = col;
        }
    }
    public static List<List<Integer>> verticalTraversal(TreeNode root) {
        Map<TreeNode, int[]> map = new HashMap<>();
        Map<Integer, List<Node>> nodes = new HashMap<>();
        List<List<Integer>> res = new LinkedList<>();
        map.put(root, new int[]{ 0, 0 });
        Queue<TreeNode> queue = new ArrayDeque<>();
        queue.offer(root);
        int min = 0, max = 0;
        while (!queue.isEmpty()) {
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                int[] indexes = map.get(cur);
                if (!nodes.containsKey(indexes[1]))
                    nodes.put(indexes[1], new LinkedList<>());
                nodes.get(indexes[1]).add(new Node(cur.val, indexes[0], indexes[1]));
                max = Math.max(max, indexes[1]);
                min = Math.min(min, indexes[1]);
                if (cur.left != null) {
                    queue.offer(cur.left);
                    map.put(cur.left, new int[] { indexes[0] + 1, indexes[1] - 1 });
                } if (cur.right != null) {
                    queue.offer(cur.right);
                    map.put(cur.right, new int[] { indexes[0] + 1, indexes[1] + 1 });
                }
            }
        }
        for (int i = min; i <= max; i++) {
            List<Node> level = nodes.get(i);
            Collections.sort(level, (a, b) -> a.row == b.row ? a.val - b.val : a.row - b.row);
            List<Integer> temp = new LinkedList<>();
            for (Node node : level)
                temp.add(node.val);
            res.add(temp);
        }
        return res;
    }
}
