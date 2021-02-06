package com.company;

import com.sun.source.tree.Tree;

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
	// write your code here
    }
    int min = Integer.MAX_VALUE;
    public int minDepth_dfs(TreeNode root) {
        if(root == null) return 0;
        dfs(root, 1);
        return min;
    }
    public void dfs(TreeNode node, int depth){
        if(node == null) return;
        if(node.left == node.right) min = Math.min(min, depth);
        dfs(node.left, depth + 1);
        dfs(node.right, depth + 1);
    }

    public int minDepth_bfs(TreeNode root) {
        if(root == null) return 0;
        ArrayDeque<TreeNode> queue = new ArrayDeque<>(){{offer(root);}};
        int depth = 0;
        while (!queue.isEmpty()){
            int count = queue.size();
            depth++;
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                if(cur.left == cur.right) return depth;
                if(cur.left != null) queue.offer(cur.left);
                if(cur.right != null) queue.offer(cur.right);
            }
        }
        return -1;
    }
}
