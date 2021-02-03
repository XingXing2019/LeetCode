package com.company;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Collections;

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

    }

    int sum;
    public int sumRootToLeaf(TreeNode root) {
        dfs(root, 0);
        return sum;
    }

    public void dfs(TreeNode root, int num){
        if (root == null) return;
        if(root.left == root.right) sum += num * 2 + root.val;
        dfs(root.left, num * 2 + root.val);
        dfs(root.right, num * 2 + root.val);
    }
}
