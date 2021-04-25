package com.company;

import java.util.*;

class ListNode {
      int val;
      ListNode next;
      ListNode() {}
      ListNode(int val) { this.val = val; }
      ListNode(int val, ListNode next) { this.val = val; this.next = next; }
  }

public class Main {

    public static void main(String[] args) {
        ListNode head = generate(new int[]{1, 2, 3, -3, 3});
        System.out.println(removeZeroSumSublists(head));
    }
    public static ListNode removeZeroSumSublists(ListNode head) {
        Stack<ListNode> stack = new Stack<>();
        int sum = 0;
        HashSet<Integer> set = new HashSet<>(){{add(0);}};
        while (head != null){
            sum += head.val;
            if (!set.add(sum)) {
                int temp = sum;
                sum -= head.val;
                while (!stack.isEmpty() && sum != temp) {
                    set.remove(sum);
                    sum -= stack.pop().val;
                }
            } else {
                if (!stack.isEmpty())
                    stack.peek().next = head;
                stack.push(head);
            }
            head = head.next;
        }
        if(stack.isEmpty()) return null;
        stack.peek().next = null;
        ListNode res = null;
        while (!stack.isEmpty())
            res = stack.pop();
        return res;
    }

    public static ListNode generate(int[] nums){
        ListNode res = null;
        for (int i = nums.length - 1; i >= 0; i--)
            res = new ListNode(nums[i], res);
        return res;
    }
}
