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

    public ListNode removeElements(ListNode head, int val) {
        ListNode dummy = new ListNode(0, head), point = dummy;
        while (head != null) {
            while (head != null && head.val == val)
                head = head.next;
            point.next = head;
            point = point.next;
            if (head != null)
                head = head.next;
        }
        return dummy.next;
    }
}
