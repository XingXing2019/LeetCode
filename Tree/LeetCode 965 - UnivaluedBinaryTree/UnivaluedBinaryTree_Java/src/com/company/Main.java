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
	// write your code here
    }

    public boolean isUnivalTree_bfs(TreeNode root) {
        if (root == null) return true;
        ArrayDeque<TreeNode> queue = new ArrayDeque<>(){{offer(root);}};
        while (!queue.isEmpty()){
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                if(cur.val != root.val) return false;
                if(cur.left != null) queue.offer(cur.left);
                if(cur.right != null) queue.offer(cur.right);
            }
        }
        return true;
    }

    public boolean isUnivalTree_dfs(TreeNode root) {
        if(root == null) return true;
        return dfs(root, root.val);
    }
    public boolean dfs(TreeNode root, int val){
        if(root == null) return true;
        if(root.val != val) return false;
        return dfs(root.left, val) && dfs(root.right, val);
    }
}
