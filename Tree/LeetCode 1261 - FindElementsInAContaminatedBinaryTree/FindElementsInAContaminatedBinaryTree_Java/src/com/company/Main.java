package com.company;

import java.util.HashSet;

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
}

class FindElements {

    HashSet<Integer> nodes;
    public FindElements(TreeNode root) {
        root.val = 0;
        nodes = new HashSet<>(){{add(root.val);}};
        dfs(root);
    }

    private TreeNode dfs(TreeNode root){
        if(root == null) return null;
        nodes.add(root.val);
        if(root.left != null)
            root.left.val = root.val * 2 + 1;
        if(root.right != null)
            root.right.val = root.val * 2 + 2;
        dfs(root.left);
        dfs(root.right);
        return root;
    }

    public boolean find(int target) {
        return nodes.contains(target);
    }
}

