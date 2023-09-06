package com.company;

public class Main {

    public class ListNode {
      int val;
      ListNode next;
      ListNode() {}
      ListNode(int val) { this.val = val; }
      ListNode(int val, ListNode next) { this.val = val; this.next = next; }
  }
    public static void main(String[] args) {
	// write your code here
    }

    public ListNode[] splitListToParts(ListNode head, int k) {
        int len = getLen(head), each = len / k, extra = len % k;
        ListNode[] res = new ListNode[k];
        for (int i = 0; i < k; i++) {
            ListNode dummy = new ListNode(), point = dummy;
            for (int j = 0; j < each; j++) {
                point.next = head;
                point = point.next;
                head = head.next;
            }
            if (extra != 0) {
                point.next = head;
                point = point.next;
                head = head.next;
                extra--;
            }
            point.next = null;
            res[i] = dummy.next;
        }
        return res;
    }

    public int getLen(ListNode head) {
        int res = 0;
        while (head != null) {
            res++;
            head = head.next;
        }
        return res;
    }
}
