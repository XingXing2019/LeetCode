package com.company;

import java.util.ArrayList;

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
    public ListNode swapNodes_list(ListNode head, int k) {
        ArrayList<ListNode> nodes = new ArrayList<>();
        while (head != null){
            nodes.add(head);
            head = head.next;
        }
        ListNode temp = nodes.get(k - 1);
        nodes.set(k - 1, nodes.get(nodes.size() - k));
        nodes.set(nodes.size() - k, temp);
        for (int i = 0; i < nodes.size(); i++)
            nodes.get(i).next = i == nodes.size() - 1 ? null : nodes.get(i + 1);
        return nodes.get(0);
    }

    public ListNode swapNodes_twoPointers(ListNode head, int k) {
        ListNode fast = head, slow = head;
        for (int i = 0; i < k - 1; i++)
            fast = fast.next;
        ListNode record = fast;
        while (fast.next != null){
            fast = fast.next;
            slow = slow.next;
        }
        int temp = record.val;
        record.val = slow.val;
        slow.val = temp;
        return head;
    }
}
