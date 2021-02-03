package com.company;

import java.util.ArrayList;
import java.util.List;

class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public TreeNode IncreasingBST(TreeNode root) {
        List<TreeNode> nodes = new ArrayList<>();
        dfs(root, nodes);
        for (int i = 0; i < nodes.size(); i++) {
            nodes.get(i).left = null;
            nodes.get(i).right = i == nodes.size() - 1 ? null : nodes.get(i + 1);
        }
        return nodes.get(0);
    }

    public void dfs(TreeNode root, List<TreeNode> nodes) {
        if (root == null) return;
        dfs(root.left, nodes);
        nodes.add(root);
        dfs(root.right, nodes);
    }
}
