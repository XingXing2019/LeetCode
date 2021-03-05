package com.company;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

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
        sortList(head);
    }
    public static ListNode sortList(ListNode head) {
        if(head == null) return null;
        ListNode dummy = new ListNode(0, head);
        while (head.next != null){
            if(head.val <= head.next.val)
                head = head.next;
            else {
                ListNode point = dummy;
                while (point.next.val <= head.next.val)
                    point = point.next;
                ListNode next = head.next;
                head.next = next.next;
                next.next = point.next;
                point.next = next;
            }
        }
        return dummy.next;
    }

    public static ListNode sortList_sort(ListNode head) {
        if(head == null) return null;
        List<ListNode> nodes = new ArrayList<>();
        while (head != null){
            nodes.add(head);
            head = head.next;
        }
        Collections.sort(nodes, Comparator.comparingInt(a -> a.val));
        for (int i = 0; i < nodes.size(); i++)
            nodes.get(i).next = i == nodes.size() - 1 ? null : nodes.get(i + 1);
        return nodes.get(0);
    }

    public static ListNode generate(int[] nums){
        ListNode res = null;
        for (int i = nums.length - 1; i >= 0; i--)
            res = new ListNode(nums[i], res);
        return res;
    }
}
