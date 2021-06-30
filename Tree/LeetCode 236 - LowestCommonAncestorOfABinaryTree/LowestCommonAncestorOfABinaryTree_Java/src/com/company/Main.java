package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

class TreeNode {
      int val;
      TreeNode left;
      TreeNode right;
      TreeNode(int x) { val = x; }
  }

public class Main {

    public static void main(String[] args) {
        TreeNode a = new TreeNode(3);
        TreeNode b = new TreeNode(5);
        TreeNode c = new TreeNode(1);
        TreeNode d = new TreeNode(6);
        TreeNode e = new TreeNode(2);
        TreeNode f = new TreeNode(0);
        TreeNode g = new TreeNode(8);
        TreeNode h = new TreeNode(7);
        TreeNode i = new TreeNode(4);

        a.left = b;
        a.right = c;
        b.left = d;
        b.right = e;
        c.left = f;
        c.right = g;
        e.left = h;
        e.right = i;

        System.out.println(lowestCommonAncestor(a, b, c));
    }

    static boolean found;
    public static TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        Queue<TreeNode> ancestorsP = new ArrayDeque<>();
        Queue<TreeNode> ancestorsQ = new ArrayDeque<>();
        dfs(root, p, ancestorsP);
        found = false;
        dfs(root, q, ancestorsQ);
        while (ancestorsP.size() > ancestorsQ.size())
            ancestorsP.poll();
        while (ancestorsQ.size() > ancestorsP.size())
            ancestorsQ.poll();
        while (!ancestorsP.isEmpty()){
            if(ancestorsP.peek() == ancestorsQ.peek())
                return ancestorsP.peek();
            ancestorsP.poll();
            ancestorsQ.poll();
        }
        return null;
    }

    private static void dfs(TreeNode node, TreeNode target, Queue<TreeNode> ancestors){
        if (node == null || found) return;
        if (node.val == target.val) {
            ancestors.offer(node);
            found = true;
            return;
        }
        dfs(node.left, target, ancestors);
        dfs(node.right, target, ancestors);
        if (found) ancestors.offer(node);
    }
}
