package com.company;

import java.util.ArrayDeque;
import java.util.HashMap;
import java.util.Map;

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
	    TreeNode a = new TreeNode(1);
	    TreeNode b = new TreeNode(7);
	    TreeNode c = new TreeNode(0);
	    TreeNode d = new TreeNode(7);
	    TreeNode e = new TreeNode(-8);

	    a.left = b;
	    a.right = c;
	    b.left = d;
	    b.right = e;

	    maxLevelSum(a);
    }

    public static int maxLevelSum(TreeNode root) {
        Map<Integer, Integer> map = new HashMap<>();
        ArrayDeque<TreeNode> queue = new ArrayDeque<>(){{offer(root);}};
        int level = 1, max = Integer.MIN_VALUE;
        while (!queue.isEmpty()){
            int count = queue.size();
            int sum = 0;
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                sum += cur.val;
                if(cur.left != null) queue.offer(cur.left);
                if(cur.right != null) queue.offer(cur.right);
            }
            max = Math.max(max, sum);
            if(!map.containsKey(sum)) map.put(sum, level);
            level++;
        }
        return map.get(max);
    }
}
