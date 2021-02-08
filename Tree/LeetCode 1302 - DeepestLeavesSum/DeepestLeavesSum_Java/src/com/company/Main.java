package com.company;

import java.util.ArrayDeque;
import java.util.ArrayList;
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
	// write your code here
    }

    public int deepestLeavesSum_bfs(TreeNode root) {
        ArrayDeque<TreeNode> queue = new ArrayDeque<>(){{offer(root);}};
        ArrayList<Integer> leavesSum = new ArrayList<>();
        while (!queue.isEmpty()){
            int count = queue.size();
            int sum = 0;
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                if(cur.left == cur.right) sum += cur.val;
                if(cur.left != null) queue.offer(cur.left);
                if(cur.right != null) queue.offer(cur.right);
            }
            leavesSum.add(sum);
        }
        return leavesSum.get(leavesSum.size() - 1);
    }

    int deepest = 0;
    Map<Integer, Integer> map;
    public int deepestLeavesSum_dfs(TreeNode root) {
        map = new HashMap<>();
        dfs(root, 0);
        return map.get(deepest);
    }

    public void dfs(TreeNode node, int depth){
        if(node == null) return;
        if(node.left == node.right)
        {
            map.put(depth, map.getOrDefault(depth, 0) + node.val);
            deepest = Math.max(deepest, depth);
        }
        dfs(node.left, depth + 1);
        dfs(node.right, depth + 1);
    }
}
