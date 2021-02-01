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
    public ListNode deleteDuplicates(ListNode head) {
        ListNode dummy = new ListNode(0, head), point = dummy;
        while (head != null && head.next != null){
            while (head.next != null && head.val == head.next.val)
                head = head.next;
            point.next = head;
            head = head.next;
            point = point.next;
        }
        point.next = head;
        return dummy.next;
    }
}
