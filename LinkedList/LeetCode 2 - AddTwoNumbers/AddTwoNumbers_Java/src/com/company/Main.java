package com.company;

public class ListNode {
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
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        var dummy = new ListNode();
        var point = dummy;
        int cur = 0, car = 0;
        while (l1 != null && l2 != null){
            cur = (l1.val + l2.val + car) % 10;
            car = (l1.val + l2.val + car) / 10;
            point.next = new ListNode(cur);
            l1 = l1.next;
            l2 = l2.next;
            point = point.next;
            if(l1 == null && l2 != null)
                l1 = new ListNode();
            if(l1 != null && l2 == null)
                l2 = new ListNode();
        }
        if(car == 1) point.next = new ListNode(car);
        return dummy.next;
    }
}
