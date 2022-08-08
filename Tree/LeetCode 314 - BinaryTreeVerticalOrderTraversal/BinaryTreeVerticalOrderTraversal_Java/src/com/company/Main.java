package com.company;

import java.util.*;

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

    class Node {
        TreeNode node;
        int index;

        public Node(TreeNode node, int index) {
            this.node = node;
            this.index = index;
        }
    }

    public List<List<Integer>> verticalOrder(TreeNode root) {
        List<List<Integer>> res = new ArrayList<>();
        if (root == null) return res;
        Queue<Node> queue = new ArrayDeque<>();
        Map<Integer, List<Integer>> map = new HashMap<>();
        queue.offer(new Node(root, 0));
        List<Integer> indexes = new LinkedList<>();
        while (!queue.isEmpty()) {
            int size = queue.size();
            for (int i = 0; i < size; i++) {
                Node cur = queue.poll();
                if (!map.containsKey(cur.index)) {
                    map.put(cur.index, new ArrayList<>());
                    indexes.add(cur.index);
                }
                map.get(cur.index).add(cur.node.val);
                if (cur.node.left != null)
                    queue.offer(new Node(cur.node.left, cur.index - 1));
                if (cur.node.right != null)
                    queue.offer(new Node(cur.node.right, cur.index + 1));
            }
        }
        Collections.sort(indexes);
        for (int index : indexes) {
            res.add(map.get(index));
        }
        return res;
    }
}
