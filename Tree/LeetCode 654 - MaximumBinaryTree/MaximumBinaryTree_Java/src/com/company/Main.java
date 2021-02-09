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

    public TreeNode constructMaximumBinaryTree(int[] nums) {
        return dfs(nums, 0, nums.length - 1);
    }
    public TreeNode dfs(int[] nums, int li, int hi){
        if(hi < li) return null;
        int index = findMaxIndex(nums, li, hi);
        TreeNode root = new TreeNode(nums[index]);
        root.left = dfs(nums, li, index - 1);
        root.right = dfs(nums, index + 1, hi);
        return root;
    }
    public int findMaxIndex(int[] nums, int li , int hi){
        int index = -1, max = Integer.MIN_VALUE;
        for (int i = li; i <= hi; i++) {
            if(nums[i] > max){
                max = nums[i];
                index = i;
            }
        }
        return index;
    }
}
