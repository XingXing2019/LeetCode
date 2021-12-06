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
	// write your code here
    }

    public String getDirections(TreeNode root, int startValue, int destValue) {
        StringBuilder s = new StringBuilder(), d = new StringBuilder();
        dfs(root, startValue, s);
        dfs(root, destValue, d);
        int count = 0, max_i = Math.min(d.length(), s.length());
        while (count < max_i && s.charAt(s.length() - count - 1) == d.charAt(d.length() - count - 1))
            ++count;
        return "U".repeat(s.length() - count) + d.reverse().toString().substring(count);
    }

    public boolean dfs(TreeNode node, int target, StringBuilder str) {
        if (node == null) return false;
        if (node.val == target) return true;
        if (dfs(node.left, target, str))
            str.append('L');
        else if (dfs(node.right, target, str))
            str.append('R');
        return str.length() > 0;
    }
}
