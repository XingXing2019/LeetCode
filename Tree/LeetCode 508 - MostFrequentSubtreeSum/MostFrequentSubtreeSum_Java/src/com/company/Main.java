package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

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

    int max;
    public int[] findFrequentTreeSum(TreeNode root) {
        Map<Integer, Integer> map = new HashMap<>();
        dfs(root, map);
        ArrayList<Integer> subSums = new ArrayList<>();
        for (int key : map.keySet()){
            if(map.get(key) == max)
                subSums.add(key);
        }
        int[] res = new int[subSums.size()];
        for (int i = 0; i < res.length; i++)
            res[i] = subSums.get(i);
        return res;
    }

    public int dfs(TreeNode node, Map<Integer, Integer> map){
        if(node == null) return 0;
        int sum = dfs(node.left, map) + dfs(node.right, map) + node.val;
        map.put(sum, map.getOrDefault(sum, 0) + 1);
        max = Math.max(max, map.get(sum));
        return sum;
    }
}
