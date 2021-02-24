package com.company;

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

    public boolean isSubPath(ListNode head, TreeNode root) {
        if(head == null) return true;
        if(root == null) return false;
        return check(head, root) || isSubPath(head, root.left) || isSubPath(head, root.right);
    }

    public boolean check(ListNode head, TreeNode root){
        if(head == null) return true;
        if(root == null) return false;
        return head.val == root.val && (check(head.next, root.left) || check(head.next, root.right));
    }
}
