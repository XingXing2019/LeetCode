package com.company;

import java.util.ArrayList;
import java.util.List;

class ListNode {
      int val;
      ListNode next;
      ListNode() {}
      ListNode(int val) { this.val = val; }
      ListNode(int val, ListNode next) { this.val = val; this.next = next; }
  }


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
    public static TreeNode sortedListToBST(ListNode head) {
        List<Integer> nums = new ArrayList<>();
        while (head != null){
            nums.add(head.val);
            head = head.next;
        }
        return dfs(nums, 0, nums.size() - 1);
    }
    public static TreeNode dfs(List<Integer> nums, int li, int hi){
        if (hi < li) return null;
        int mid = (hi + li) / 2;
        TreeNode root = new TreeNode(nums.get(mid));
        root.left = dfs(nums, li, mid - 1);
        root.right = dfs(nums, mid + 1, hi);
        return root;
    }
}
