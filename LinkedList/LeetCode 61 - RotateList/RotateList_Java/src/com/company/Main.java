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
	// write your code here
    }

    public ListNode rotateRight(ListNode head, int k) {
        if (head == null) return null;
        ListNode dummy = new ListNode(0, head);
        ListNode fast = head, slow = head;
        int len = getLen(head);
        for (int i = 0; i < k % len; i++)
            fast = fast.next;
        while (fast.next != null) {
            fast = fast.next;
            slow = slow.next;
        }
        fast.next = dummy.next;
        dummy.next = slow.next;
        slow.next = null;
        return dummy.next;
    }

    public int getLen(ListNode head){
        int len = 0;
        while (head != null){
            head = head.next;
            len++;
        }
        return len;
    }
}
