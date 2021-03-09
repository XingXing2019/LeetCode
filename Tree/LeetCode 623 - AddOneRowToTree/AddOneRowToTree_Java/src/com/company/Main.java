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
        TreeNode a = new TreeNode(1);
        TreeNode b = new TreeNode(2);
        TreeNode c = new TreeNode(3);
        TreeNode e = new TreeNode(4);
        a.left = b;
        a.right = c;
        b.left = e;
        int v = 5, d = 4;
        addOneRow(a, v, d);
    }

    public static TreeNode addOneRow(TreeNode root, int v, int d) {
        if(d == 1) return new TreeNode(v, root, null);
        dfs(root, null, v, d, new HashSet<>());
        return root;
    }

    public static void dfs(TreeNode child, TreeNode parent, int v, int d, HashSet<TreeNode> set) {
        if (d == 1 && set.add(parent)) {
            parent.left = new TreeNode(v, parent.left, null);
            parent.right = new TreeNode(v, null, parent.right);
        }
        if(child == null) return;
        dfs(child.left, child, v, d - 1, set);
        dfs(child.right, child, v, d - 1, set);
    }
}
