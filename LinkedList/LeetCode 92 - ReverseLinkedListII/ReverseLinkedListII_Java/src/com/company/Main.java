package com.company;

class ListNode {
      int val;
      ListNode next;
      ListNode() {}
      ListNode(int val) { this.val = val; }
      ListNode(int val, ListNode next) { this.val = val; this.next = next; }
  }

public class Main {

    public static void main(String[] args) {
	    ListNode head = generate(new int[]{1, 2, 3, 4, 5});
	    int left = 1, right = 5;
	    reverseBetween(head, left, right);
    }
    public static ListNode reverseBetween(ListNode head, int left, int right) {
        ListNode dummy = new ListNode(0, head);
        for (int i = 0; i < left - 1; i++)
            dummy = dummy.next;
        ListNode point = dummy.next;
        for (int i = 0; i < right - left; i++) {
            ListNode next = point.next;
            point.next = next.next;
            next.next = dummy.next;
            dummy.next = next;
        }
        return left == 1 ? dummy.next : head;
    }

    public static ListNode generate(int[] nums){
        ListNode res = null;
        for (int i = nums.length - 1; i >= 0; i--)
            res = new ListNode(nums[i], res);
        return res;
    }
}
