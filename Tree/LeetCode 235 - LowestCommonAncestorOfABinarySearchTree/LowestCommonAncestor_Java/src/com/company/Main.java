package com.company;

import java.util.ArrayDeque;

class TreeNode {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode(int x) { val = x; }
  }

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    boolean found;
    public TreeNode lowestCommonAncestor_dfs(TreeNode root, TreeNode p, TreeNode q) {
        ArrayDeque<TreeNode> pAncestors = new ArrayDeque<>();
        ArrayDeque<TreeNode> qAncestors = new ArrayDeque<>();
        dfs(root, p, pAncestors);
        found = false;
        dfs(root, q, qAncestors);
        while (pAncestors.size() > qAncestors.size()) pAncestors.poll();
        while (qAncestors.size() > pAncestors.size()) qAncestors.poll();
        while (!pAncestors.isEmpty() && !qAncestors.isEmpty()){
            if (pAncestors.peek() == qAncestors.peek()) return pAncestors.peek();
            pAncestors.poll();
            qAncestors.poll();
        }
        return root;
    }
    public void dfs(TreeNode node, TreeNode p, ArrayDeque<TreeNode> ancestors){
        if(node == null || found) return;
        if(node == p) found = true;
        if(node.val > p.val) dfs(node.left, p, ancestors);
        else dfs(node.right, p, ancestors);
        if(found) ancestors.offer(node);
    }

    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if(root == null) return null;
        if(p.val < root.val && q.val < root.val) return lowestCommonAncestor(root.left, p, q);
        else if(p.val > root.val && q.val > root.val) return lowestCommonAncestor(root.right, p, q);
        return root;
    }
}
