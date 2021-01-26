package com.company;

import java.util.ArrayList;
import java.util.HashMap;

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

    int max = 0;
    public int[] findMode(TreeNode root) {
        HashMap<Integer, Integer> map = new HashMap<>();
        dfs(root, map);
        ArrayList<Integer> res = new ArrayList<>();
        for (var kv: map.entrySet()) {
            if(kv.getValue() == max)
                res.add(kv.getKey());
        }
        return res.stream().mapToInt(x -> x).toArray();
    }

    public void dfs(TreeNode node, HashMap<Integer, Integer> map){
        if(node == null) return;
        dfs(node.left, map);
        if(!map.containsKey(node.val))
            map.put(node.val, 1);
        else
            map.put(node.val, map.get(node.val) + 1);
        max = Math.max(max, map.get(node.val));
        dfs(node.right, map);
    }
}
