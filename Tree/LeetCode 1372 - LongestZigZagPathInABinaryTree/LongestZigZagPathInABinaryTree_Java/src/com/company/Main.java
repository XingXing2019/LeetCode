package com.company;

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
	    TreeNode a = new TreeNode(1);
	    TreeNode b = new TreeNode(1);
	    TreeNode c = new TreeNode(1);
	    TreeNode d = new TreeNode(1);
	    TreeNode e = new TreeNode(1);
	    TreeNode f = new TreeNode(1);
	    TreeNode g = new TreeNode(1);

	    a.left = b;
	    a.right = c;
	    b.right = d;
	    d.left = e;
	    d.right = f;
	    e.right = g;

        System.out.println(longestZigZag(a));
    }

    private static int res;
    public static int longestZigZag(TreeNode root) {
        dfs(root, 0, true);
        dfs(root, 0, false);
        return res;
    }

    public static void dfs(TreeNode node, int len, boolean isLeft){
        if (node == null)
            return;
        res = Math.max(res, len);
        if (isLeft) {
            dfs(node.right, len + 1, false);
            dfs(node.left, 1, true);
        } else {
            dfs(node.left, len + 1, true);
            dfs(node.right, 1, false);
        }
    }
}
