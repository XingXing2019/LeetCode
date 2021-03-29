package com.company;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

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

class BSTIterator {
    List<Integer> nodes;
    int index;
    public BSTIterator(TreeNode root) {
        nodes = new ArrayList<>();
        dfs(root);
    }
    private void dfs(TreeNode node) {
        if (node == null) return;
        dfs(node.left);
        nodes.add(node.val);
        dfs(node.right);
    }
    public int next() {
        return nodes.get(index++);
    }
    public boolean hasNext() {
        return index < nodes.size();
    }
}
