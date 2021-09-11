package com.company;

import java.util.ArrayList;
import java.util.List;
import java.util.PriorityQueue;

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

    public List<Integer> closestKValues(TreeNode root, double target, int k) {
        PriorityQueue<Integer> heap = new PriorityQueue<>((a, b) -> Double.compare(Math.abs(b - target), Math.abs(a - target)));
        dfs(root, k, heap);
        List<Integer> res = new ArrayList<>();
        while (!heap.isEmpty())
            res.add(heap.poll());
        return res;
    }

    public void dfs(TreeNode root, int k, PriorityQueue<Integer> heap) {
        if (root == null) return;
        dfs(root.left, k, heap);
        heap.offer(root.val);
        if (heap.size() > k)
            heap.poll();
        dfs(root.right, k, heap);
    }
}
