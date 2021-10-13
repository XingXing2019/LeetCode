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
        int[] preorder = {8, 5, 1, 7, 10, 12};
        System.out.println(bstFromPreorder(preorder));
    }

    public static TreeNode bstFromPreorder(int[] preorder) {
        return dfs(preorder, 0, preorder.length - 1);
    }

    public static TreeNode dfs(int[] preorder, int li, int hi){
        if (li > hi) return null;
        TreeNode root = new TreeNode(preorder[li]);
        int index = li;
        while (index <= hi) {
            if (preorder[index] > preorder[li])
                break;
            index++;
        }
        root.left = dfs(preorder, li + 1, index - 1);
        root.right = dfs(preorder, index, hi);
        return root;
    }
}
