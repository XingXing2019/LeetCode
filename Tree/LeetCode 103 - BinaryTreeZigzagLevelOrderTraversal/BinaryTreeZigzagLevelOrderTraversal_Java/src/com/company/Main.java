package com.company;

import java.lang.reflect.Array;
import java.util.*;

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
    public List<List<Integer>> zigzagLevelOrder(TreeNode root) {
        List<List<Integer>> res = new ArrayList<>();
        if(root ==  null) return res;
        boolean reverse = false;
        ArrayDeque<TreeNode> queue = new ArrayDeque<>(){{offer(root);}};
        while (!queue.isEmpty()){
            int count = queue.size();
            List<Integer> temp = new ArrayList<>();
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                temp.add(cur.val);
                if(cur.left != null) queue.offer(cur.left);
                if(cur.right != null) queue.offer(cur.right);
            }
            if(reverse) Collections.reverse(temp);
            res.add(temp);
            reverse = !reverse;
        }
        return res;
    }
}
