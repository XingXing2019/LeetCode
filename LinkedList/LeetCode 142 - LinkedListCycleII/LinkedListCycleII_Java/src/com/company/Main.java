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

    public ListNode detectCycle(ListNode head) {
        ListNode fast = head, slow = head, meet = null;
        while (fast != null && slow != null){
            fast = fast.next;
            if(fast == null) return null;
            fast = fast.next;
            slow = slow.next;
            if(fast == slow){
                meet = fast;
                break;
            }
        }
        if(meet == null) return null;
        while (meet != head){
            meet = meet.next;
            head = head.next;
        }
        return head;
    }
}
