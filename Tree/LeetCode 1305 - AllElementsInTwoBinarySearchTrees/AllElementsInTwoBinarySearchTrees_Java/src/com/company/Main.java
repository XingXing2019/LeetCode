package com.company;

import java.util.ArrayList;
import java.util.List;
import java.util.PriorityQueue;

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

    PriorityQueue<Integer> heap;
    public List<Integer> getAllElements(TreeNode root1, TreeNode root2) {
        heap = new PriorityQueue<Integer>();
        dfs(root1);
        dfs(root2);
        List<Integer> res = new ArrayList<>();
        while (!heap.isEmpty())
            res.add(heap.poll());
        return res;
    }
    public void dfs(TreeNode node){
        if(node == null) return;
        dfs(node.left);
        heap.offer(node.val);
        dfs(node.right);
    }    
}
