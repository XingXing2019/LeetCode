package com.company;

import java.util.ArrayList;

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

    String res = "";
    public String smallestFromLeaf(TreeNode root) {
        dfs(root, new StringBuilder());
        return res;
    }

    public void dfs(TreeNode root, StringBuilder path){
        if(root == null) return;
        path.append((char) (root.val + 'a'));
        if(root.left == root.right){
            path.reverse();
            String word = path.toString();
            path.reverse();
            if(res == "" || word.compareTo(res) < 0)
                res = word;
        }
        dfs(root.left, path);
        dfs(root.right, path);
        path.deleteCharAt(path.length() - 1);
    }
}
