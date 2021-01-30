package com.company;

class ListNode {
      int val;
      ListNode next;
      ListNode(int x) {
          val = x;
          next = null;
      }
  }

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public boolean hasCycle(ListNode head) {
        ListNode fast = head, slow = head;
        while (fast != null && slow != null){
            fast = fast.next;
            if(fast == null) return false;
            fast = fast.next;
            slow = slow.next;
            if(fast == slow) return true;
        }
        return false;
    }
}
