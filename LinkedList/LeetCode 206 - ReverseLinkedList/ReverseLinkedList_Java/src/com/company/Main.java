package com.company;

public class ListNode {
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

    public ListNode reverseList(ListNode head) {
        if (head == null) return null;
        var dummy = new ListNode(0, head);
        while (head.next != null) {
            var post = head.next;
            head.next = post.next;
            post.next = dummy.next;
            dummy.next = post;
        }
        return dummy.next;
    }
}
