package com.company;

import java.text.DateFormatSymbols;
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
	    TreeNode a = new TreeNode(10);
	    TreeNode b = new TreeNode(5);
	    TreeNode c = new TreeNode(-3);
	    TreeNode d = new TreeNode(3);
	    TreeNode e = new TreeNode(2);
	    TreeNode f = new TreeNode(11);
	    TreeNode g = new TreeNode(3);
	    TreeNode h = new TreeNode(-2);
	    TreeNode i = new TreeNode(1);

	    a.left = b;
	    a.right = c;
	    b.left = d;
	    b.right = e;
	    c.right = f;
	    d.left = g;
	    d.right = h;
	    e.right = i;

	    int sum = 8;
	    System.out.println(pathSum(a, 8));
    }
    int res;
    public int pathSum(TreeNode root, int sum) {
        dfs(root, new HashMap<Integer, Integer>(){{put(0, 1);}}, sum, 0);
        return res;
    }
    public void dfs(TreeNode node, Map<Integer, Integer> prefix, int sum, int pathSum){
        if(node == null) return;
        pathSum += node.val;
        res += prefix.getOrDefault(pathSum - sum, 0);
        prefix.put(pathSum, prefix.getOrDefault(pathSum, 0) + 1);
        dfs(node.left, prefix, sum, pathSum);
        dfs(node.right, prefix, sum, pathSum);
        prefix.put(pathSum, prefix.getOrDefault(pathSum, 0) - 1);
    }
}
