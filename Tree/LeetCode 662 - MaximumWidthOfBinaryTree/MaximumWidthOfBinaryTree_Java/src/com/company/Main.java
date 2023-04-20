package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

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

class Node {
    TreeNode treeNode;
    int index;
    public Node(TreeNode treeNode, int index) {
        this.treeNode = treeNode;
        this.index = index;
    }
}

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int widthOfBinaryTree(TreeNode root) {
        Queue<Node> queue = new ArrayDeque<>();
        queue.offer(new Node(root, 1));
        int res = 0;
        while (!queue.isEmpty()) {
            int count = queue.size();
            int first = 0, last = 0;
            for (int i = 0; i < count; i++) {
                Node cur = queue.poll();
                if (i == 0) first = cur.index;
                if (i == count - 1) last = cur.index;
                if (cur.treeNode.left != null)
                    queue.offer(new Node(cur.treeNode.left, cur.index * 2));
                if (cur.treeNode.right != null)
                    queue.offer(new Node(cur.treeNode.right, cur.index * 2 + 1));
            }
            res = Math.max(res, last - first + 1);
        }
        return res;
    }
}
