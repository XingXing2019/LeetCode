package com.company;

import java.util.*;

public class Main {

    public class TreeNode {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode(int x) { val = x; }
    }

    public static void main(String[] args) {
	// write your code here
    }

    public List<Integer> distanceK(TreeNode root, TreeNode target, int k) {
        Map<TreeNode, TreeNode> parents = new HashMap<>();
        dfs(null, root, parents);
        Queue<TreeNode> queue = new ArrayDeque<>();
        HashSet<TreeNode> visited = new HashSet<>();
        queue.offer(target);
        visited.add(target);
        List<Integer> res = new ArrayList<>();
        while (!queue.isEmpty() && k >= 0) {
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                if (k == 0) res.add(cur.val);
                if (cur.left != null && visited.add(cur.left)) queue.offer(cur.left);
                if (cur.right != null && visited.add(cur.right)) queue.offer(cur.right);
                if (parents.containsKey(cur) && visited.add(parents.get(cur))) queue.offer(parents.get(cur));
            }
            k--;
        }
        return res;
    }

    private void dfs(TreeNode parent, TreeNode node, Map<TreeNode, TreeNode> parents) {
        if (node == null) return;
        if (parent != null)
            parents.put(node, parent);
        dfs(node, node.left, parents);
        dfs(node, node.right, parents);
    }
}
