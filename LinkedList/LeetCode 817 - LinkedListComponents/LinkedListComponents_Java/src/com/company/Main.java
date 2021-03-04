package com.company;

import java.util.HashSet;

class ListNode {
    int val;
    ListNode next;

    ListNode() {
    }

    ListNode(int val) {
        this.val = val;
    }

    ListNode(int val, ListNode next) {
        this.val = val;
        this.next = next;
    }
}

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int numComponents(ListNode head, int[] G) {
        HashSet<Integer> set = new HashSet<>();
        for (int num : G) set.add(num);
        int res = 0;
        boolean flag = false;
        while (head != null) {
            if (set.contains(head.val))
                flag = true;
            else if (!set.contains(head.val) && flag) {
                res++;
                flag = false;
            }
            head = head.next;
        }
        if(flag) res++;
        return res;
    }
}
