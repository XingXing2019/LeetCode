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
	    int[] nums = {-10, -3, 0, 5, 9};
	    sortedArrayToBST(nums);
    }

    public static TreeNode sortedArrayToBST(int[] nums) {
        return dfs(nums, 0, nums.length - 1);
    }

    public static TreeNode dfs(int[] nums, int li, int hi){
        if(hi < li) return null;
        int index = (hi - li) / 2 + li;
        TreeNode root = new TreeNode(nums[index]);
        root.left = dfs(nums, li, index - 1);
        root.right = dfs(nums, index + 1, hi);
        return root;
    }
}
