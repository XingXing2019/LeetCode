package com.company;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;

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

    public List<Integer> largestValues(TreeNode root) {
        List<Integer> res = new ArrayList<>();
        if(root == null) return res;
        ArrayDeque<TreeNode> queue = new ArrayDeque<>(){{offer(root);}};
        while(!queue.isEmpty()){
            int count = queue.size();
            int max = Integer.MIN_VALUE;
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                max = Math.max(max, cur.val);
                if(cur.left != null) queue.offer(cur.left);
                if(cur.right != null) queue.offer(cur.right);
            }
            res.add(max);
        }
        return res;
    }
}
