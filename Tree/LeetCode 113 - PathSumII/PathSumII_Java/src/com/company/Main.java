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

    public List<List<Integer>> pathSum(TreeNode root, int targetSum) {
        List<List<Integer>> res = new ArrayList<>();
        dfs(root, targetSum, new ArrayList<>(), res);
        return res;
    }
    public void dfs(TreeNode node, int targetSum, List<Integer> path, List<List<Integer>> res){
        if(node == null) return;
        path.add(node.val);
        if(node.left == node.right && targetSum == node.val)
            res.add(new ArrayList<>(path));
        dfs(node.left, targetSum - node.val, path, res);
        dfs(node.right, targetSum - node.val, path, res);
        path.remove(path.size() - 1);
    }
}
