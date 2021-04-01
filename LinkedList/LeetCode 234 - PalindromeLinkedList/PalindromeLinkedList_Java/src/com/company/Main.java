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

    public boolean isPalindrome(ListNode head) {
        ListNode point = head;
        ListNode reversed = reverse(point);
        while (head != null){
            if(head.val != reversed.val)
                return false;
            head = head.next;
            reversed = reversed.next;
        }
        return true;
    }

    public ListNode reverse(ListNode head){
        ListNode res = null;
        while (head != null){
            res = new ListNode(head.val, res);
            head = head.next;
        }
        return res;
    }
}
