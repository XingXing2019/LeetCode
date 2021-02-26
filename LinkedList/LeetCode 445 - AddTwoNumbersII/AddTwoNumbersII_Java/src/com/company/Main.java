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
	    ListNode l1 = generate(new int[]{7, 2, 4, 3});
	    ListNode l2 = generate(new int[]{5, 6, 4});
	    addTwoNumbers(l1, l2);
    }

    public static ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        ListNode reversedL1 = reverse(l1);
        ListNode reversedL2 = reverse(l2);
        ListNode point = new ListNode(), res = point;
        int car = 0, cur = 0;
        while (l1 != null && l2 != null){
            cur = (reversedL1.val + reversedL2.val + car) % 10;
            car = (reversedL1.val + reversedL2.val + car) / 10;
            point.next = new ListNode(cur);
            point = point.next;
            reversedL1 = reversedL1.next;
            reversedL2 = reversedL2.next;
            if(reversedL1 == reversedL2) break;
            if(reversedL1 == null) reversedL1 = new ListNode();
            if(reversedL2 == null) reversedL2 = new ListNode();
        }
        if(car != 0) point.next = new ListNode(car);
        return reverse(res.next);
    }

    public static ListNode reverse(ListNode head){
        ListNode dummy = new ListNode(0, head);
        while (head.next != null){
            ListNode next = head.next;
            head.next = next.next;
            next.next = dummy.next;
            dummy.next = next;
        }
        return dummy.next;
    }

    public static ListNode generate(int[] nums){
        ListNode res = null;
        for (int i = nums.length - 1; i >= 0; i--)
            res = new ListNode(nums[i], res);
        return res;
    }
}
