package com.company;

import java.util.ArrayDeque;

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
	    TreeNode a = new TreeNode(20);
	    TreeNode b = new TreeNode(15);

	    a.left = b;

	    int p = 15, q = 20;

	    findDistance(a, p, q);
    }
    static boolean found;
    static public int findDistance(TreeNode root, int p, int q) {
        ArrayDeque<TreeNode> pQueue = new ArrayDeque<>();
        dfs(root, p, pQueue);
        ArrayDeque<TreeNode> qQueue = new ArrayDeque<>();
        found = false;
        dfs(root, q, qQueue);
        int res = 0;
        while (pQueue.size() > qQueue.size()){
            res++;
            pQueue.poll();
        }
        while (qQueue.size() > pQueue.size()){
            res++;
            qQueue.poll();
        }
        while (!pQueue.isEmpty() && !qQueue.isEmpty()){
            if(pQueue.poll() == qQueue.poll()) return res;
            res += 2;
        }
        return res;
    }
    static public void dfs(TreeNode node, int target, ArrayDeque<TreeNode> queue){
        if(node == null || found) return;
        dfs(node.left, target, queue);
        dfs(node.right, target, queue);
        if(node.val == target) found = true;
        if(found) queue.offer(node);
    }
}
