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
    public TreeNode findNearestRightNode(TreeNode root, TreeNode u) {
        ArrayDeque<TreeNode> queue = new ArrayDeque(){{offer(root);}};
        while (!queue.isEmpty()){
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                if(cur == u) return i == count - 1 ? null : queue.peek();
                if(cur.left != null) queue.offer(cur.left);
                if(cur.right != null) queue.offer(cur.right);
            }
        }
        return null;
    }
}
