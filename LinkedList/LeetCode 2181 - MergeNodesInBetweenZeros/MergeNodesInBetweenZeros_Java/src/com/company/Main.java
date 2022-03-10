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

    public ListNode mergeNodes(ListNode head) {
        ListNode dummy = new ListNode(0, head);
        ListNode point = head;
        while (point != null && head != null) {
            head.val += point.val;
            point = point.next;
            if (point == null) break;
            if (point.val == 0) {
                head.next = point.next == null ? null : point;
                head = head.next;
            }
        }
        return dummy.next;
    }
}
