package com.company;

import java.awt.*;

class ListNode {
      int val;
      ListNode next;
      ListNode() {}
      ListNode(int val) { this.val = val; }
      ListNode(int val, ListNode next) { this.val = val; this.next = next; }
  }

public class Main {

    public static void main(String[] args) {
        ListNode head = generate(new int[] {4, 2, 1, 3});
        insertionSortList(head);
    }

    public static ListNode insertionSortList(ListNode head) {
        if(head == null) return null;
        ListNode dummy = new ListNode(0, head);
        while (head.next != null){
            if(head.val <= head.next.val)
                head = head.next;
            else {
                ListNode post = head.next;
                ListNode point = dummy;
                while (point.next.val <= head.next.val)
                    point = point.next;
                head.next = post.next;
                post.next = point.next;
                point.next = post;
            }
        }
        return dummy.next;
    }

    public static ListNode generate(int[] nums){
        ListNode res = null;
        for (int i = nums.length - 1; i >= 0; i--)
            res = new ListNode(nums[i], res);
        return res;
    }
}
