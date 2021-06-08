package com.company;

import java.util.Arrays;

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
        int[] preorder = {3, 9, 20, 15, 7};
        int[] inorder = {9, 3, 15, 20, 7};
        buildTree(preorder, inorder);
    }

    public static TreeNode buildTree(int[] preorder, int[] inorder) {
        if(preorder.length == 0 || inorder.length == 0) return null;
        TreeNode root = new TreeNode(preorder[0]);
        int index = indexOf(inorder, preorder[0]);
        int[] leftInorder = copyArray(inorder, 0, index - 1);
        int[] leftPreorder = copyArray(preorder, 1, leftInorder.length);
        int[] rightPreorder = copyArray(preorder, leftInorder.length + 1, preorder.length - 1);
        int[] rightInorder = copyArray(inorder, index + 1, inorder.length - 1);
        root.left = buildTree(leftPreorder, leftInorder);
        root.right = buildTree(rightPreorder, rightInorder);
        return root;
    }

    private static int[] copyArray(int[] arr, int left, int right){
        int[] res = new int[right - left + 1];
        int index = 0;
        for (int i = left; i <= right; i++)
            res[index++] = arr[i];
        return res;
    }

    private static int indexOf(int[] arr, int target){
        for (int i = 0; i < arr.length; i++) {
            if(arr[i] == target)
                return i;
        }
        return -1;
    }
}
