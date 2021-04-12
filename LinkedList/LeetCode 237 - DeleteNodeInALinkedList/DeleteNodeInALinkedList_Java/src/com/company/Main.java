package com.company;

class ListNode {
      int val;
      ListNode next;
      ListNode(int x) { val = x; }
  }

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public void deleteNode(ListNode node) {
        node.val = node.next.val;
        node.next = node.next.next;
    }
}
