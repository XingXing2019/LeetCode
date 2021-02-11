package com.company;

import java.util.ArrayDeque;
import java.util.HashMap;
import java.util.HashSet;
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
    public TreeNode CorrectBinaryTree(TreeNode root) {
        Map<TreeNode, TreeNode> map = new HashMap<>();
        map.put(root, null);
        ArrayDeque<TreeNode> queue = new ArrayDeque<>(){{offer(root);}};
        while (!queue.isEmpty()){
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                if(cur.right != null && map.containsKey(cur.right)){
                    TreeNode parent = map.get(cur);
                    if(parent.left == cur) parent.left = null;
                    else parent.right = null;
                    return root;
                }
                if(cur.right != null){
                    map.put(cur.right, cur);
                    queue.offer(cur.right);
                }
                if(cur.left != null){
                    map.put(cur.left, cur);
                    queue.offer(cur.left);
                }
            }
        }
        return root;
    }
}
