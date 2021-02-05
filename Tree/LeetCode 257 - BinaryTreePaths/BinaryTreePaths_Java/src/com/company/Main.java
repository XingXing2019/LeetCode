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

    public List<String> binaryTreePaths(TreeNode root) {
        List<String> res = new ArrayList<>();
        dfs(root, "", res);
        return res;
    }

    public void dfs(TreeNode node, String path, List<String> res){
        if(node == null) return;
        if(node.left == node.right) res.add(path + node.val);
        dfs(node.left, path + node.val + "->", res);
        dfs(node.right, path + node.val + "->", res);
    }
}
