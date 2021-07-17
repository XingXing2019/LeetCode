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

    public ListNode swapPairs(ListNode head) {
        ListNode dummy = new ListNode(0, head), point = dummy;
        while (point != null && point.next != null) {
            ListNode first = point.next, second = point.next.next;
            if (second == null) break;
            first.next = second.next;
            second.next = point.next;
            point.next = second;
            point = first;
        }
        return dummy.next;
    }
}
