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

public class Main {

    public static void main(String[] args) {
	    TreeNode a = new TreeNode(10);
	    TreeNode b = new TreeNode(5);
	    TreeNode c = new TreeNode(15);
	    TreeNode d = new TreeNode(3);
	    TreeNode e = new TreeNode(7);
	    TreeNode f = new TreeNode(18);
	    a.left = b;
	    a.right = c;
	    b.left = d;
	    b.right = e;
	    c.right = f;

	    int low = 7, high = 15;
	    System.out.println(rangeSumBST(a, low, high));
    }

    public static int rangeSumBST_dfs(TreeNode root, int low, int high) {
        if(root == null) return 0;
        int res = 0;
        if(low <= root.val && root.val <= high) res += root.val;
        if(root.val >= low) res += rangeSumBST_dfs(root.left, low, high);
        if(root.val <= high) res += rangeSumBST_dfs(root.right, low, high);
        return res;
    }
    public static int rangeSumBST_bfs(TreeNode root, int low, int high) {
        Queue<TreeNode> queue = new ArrayDeque<>();
        queue.offer(root);
        int res = 0;
        while (!queue.isEmpty()) {
            TreeNode cur = queue.poll();
            if (low <= cur.val && cur.val <= high)
                res += cur.val;
            if (cur.val < high && cur.right != null)
                queue.offer(cur.right);
            if (cur.val > low && cur.left != null)
                queue.offer(cur.left);
        }
        return res;
    }
}
