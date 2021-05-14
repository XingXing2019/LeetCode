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
        TreeNode b = new TreeNode(2);
        TreeNode c = new TreeNode(5);
        TreeNode d = new TreeNode(3);
        TreeNode e = new TreeNode(4);
        TreeNode f = new TreeNode(6);

        a.left = b;
        a.right = c;
        b.left = d;
        b.right = e;
        c.right = f;
        flatten(a);
    }
    public static void flatten(TreeNode root) {
        TreeNode pointer = root;
        while (pointer != null){
            if(pointer.left != null){
                TreeNode mostRight = pointer.left;
                while (mostRight.right != null)
                    mostRight = mostRight.right;
                mostRight.right = pointer.right;
                pointer.right = pointer.left;
                pointer.left = null;
            }
            pointer = pointer.right;
        }
    }
}
