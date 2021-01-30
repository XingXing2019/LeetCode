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
    public ListNode oddEvenList(ListNode head) {
        ListNode odd = new ListNode(), p1 = odd;
        ListNode even = new ListNode(), p2 = even;
        int count = 1;
        while (head != null){
            if(count % 2 != 0){
                p1.next = head;
                p1 = p1.next;
            }
            else{
                p2.next = head;
                p2 = p2.next;
            }
            count++;
            head = head.next;
        }
        p1.next = even.next;
        p2.next = null;
        return odd.next;
    }
}
