package com.company;

import java.util.HashSet;

class ListNode {
      int val;
      ListNode next;
      ListNode(int x, ListNode next) {
          val = x;
          this.next = next;
      }
  }

public class Main {

    public static void main(String[] args) {
        ListNode headA = generate(new int[]{2, 6, 4});
        ListNode headB = generate(new int[]{1, 5});
        getIntersectionNode_NSpace(headA, headB);
    }

    public static ListNode getIntersectionNode(ListNode headA, ListNode headB) {
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

    public static ListNode getIntersectionNode_NSpace(ListNode headA, ListNode headB) {
        if(headA == null || headB == null) return null;
        ListNode p1 = headA, p2 = headB;
        while (p1 != p2){
            p1 = p1.next;
            p2 = p2.next;
            if(p1 == p2) return p1;
            if(p1 == null) p1 = headB;
            if(p2 == null) p2 = headA;
        }
        return p1;
    }

    public static ListNode generate(int[] nums){
        ListNode res = null;
        for (int i = nums.length - 1; i >= 0; i--)
            res = new ListNode(nums[i], res);
        return res;
    }
}
