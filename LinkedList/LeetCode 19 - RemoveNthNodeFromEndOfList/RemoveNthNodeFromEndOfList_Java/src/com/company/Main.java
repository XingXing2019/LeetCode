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

    public ListNode removeNthFromEnd(ListNode head, int n) {
        ListNode reversed = reverse(head);
        ListNode dummy = new ListNode(0, reversed);
        ListNode pre = dummy;
        while (n != 1) {
            pre = pre.next;
            reversed = reversed.next;
            n--;
        }
        pre.next = reversed.next;
        return reverse(dummy.next);
    }

    public ListNode reverse(ListNode head) {
        if (head == null) return null;
        ListNode dummy = new ListNode(0, head);
        while (head.next != null) {
            ListNode next = head.next;
            head.next = next.next;
            next.next = dummy.next;
            dummy.next = next;
        }
        return dummy.next;
    }
}
