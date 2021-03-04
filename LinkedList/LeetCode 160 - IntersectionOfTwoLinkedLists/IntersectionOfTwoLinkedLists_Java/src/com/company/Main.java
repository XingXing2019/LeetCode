package com.company;

import java.util.HashSet;

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

    public ListNode getIntersectionNode(ListNode headA, ListNode headB) {
        HashSet<ListNode> nodes = new HashSet<>();
        while (headA != null){
            nodes.add(headA);
            headA = headA.next;
        }
        while (headB != null){
            if(nodes.contains(headB))
                return headB;
            headB = headB.next;
        }
        return null;
    }
}
