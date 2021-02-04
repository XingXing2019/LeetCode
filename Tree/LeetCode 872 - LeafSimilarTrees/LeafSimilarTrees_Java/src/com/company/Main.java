package com.company;

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
    public boolean leafSimilar(TreeNode root1, TreeNode root2) {
        List<Integer> nodes1 = new ArrayList<>();
        List<Integer> nodes2 = new ArrayList<>();
        dfs(root1, nodes1);
        dfs(root2, nodes2);
        return nodes1.equals(nodes2);
    }
    public void dfs(TreeNode node, List<Integer> nodes){
        if(node == null) return;
        if(node.left == node.right) nodes.add(node.val);
        dfs(node.left, nodes);
        dfs(node.right, nodes);
    }
}
