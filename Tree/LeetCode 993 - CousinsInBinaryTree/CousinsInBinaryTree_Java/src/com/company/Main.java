package com.company;

import java.util.ArrayDeque;

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

    public boolean isCousins_bfs(TreeNode root, int x, int y) {
        int parent = 0, depth = 0, level = 0;
        ArrayDeque<TreeNode> queue = new ArrayDeque<>(){{offer(root);}};
        while (!queue.isEmpty()){
            int count = queue.size();
            level++;
            for (int i = 0; i < count; i++) {
                TreeNode cur = queue.poll();
                if(cur.left != null){
                    queue.offer(cur.left);
                    if(cur.left.val == x){
                        parent += cur.val;
                        depth += level;
                    }
                    else if(cur.left.val == y){
                        parent -= cur.val;
                        depth -= level;
                    }
                }
                if(cur.right != null){
                    queue.offer(cur.right);
                    if(cur.right.val == x){
                        parent += cur.val;
                        depth += level;
                    }
                    else if(cur.right.val == y){
                        parent -= cur.val;
                        depth -= level;
                    }
                }
            }
        }
        return parent != 0 && depth == 0;
    }

    TreeNode xParent;
    TreeNode yParent;
    int depth = 0;
    public boolean isCousins_dfs(TreeNode root, int x, int y) {
        dfs(root, null, x, y, 0);
        return xParent != yParent && depth == 0;
    }
    public void dfs(TreeNode node, TreeNode parent, int x, int y, int level){
        if(node == null) return;
        if(node.val == x){
            xParent = parent;
            depth += level;
        }
        if(node.val == y){
            yParent = parent;
            depth -= level;
        }
        dfs(node.left, node, x, y, level + 1);
        dfs(node.right, node, x, y, level + 1);
    }
}
