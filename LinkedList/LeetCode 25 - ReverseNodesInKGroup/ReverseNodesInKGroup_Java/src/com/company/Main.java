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

    public ListNode reverseKGroup(ListNode head, int k) {
        ListNode dummy = new ListNode(0, head), pre = dummy, point = head;
        int len = 0;
        while (head != null) {
            len++;
            head = head.next;
        }
        for (int i = 0; i < len / k; i++) {
            for (int j = 0; j < k - 1; j++) {
                ListNode next = point.next;
                point.next = next.next;
                next.next = pre.next;
                pre.next = next;
            }
            pre = point;
            point = point.next;
        }
        return dummy.next;
    }
}
