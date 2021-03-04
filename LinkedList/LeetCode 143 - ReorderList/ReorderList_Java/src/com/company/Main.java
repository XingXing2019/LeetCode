package com.company;

import java.util.ArrayList;
import java.util.List;

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
        ListNode head = generate(new int[]{1, 2, 3, 4, 5});
        reorderList(head);
    }

    public static void reorderList(ListNode head) {
        if (head == null) return;
        List<ListNode> nodes = new ArrayList<>();
        while (head != null) {
            nodes.add(head);
            head = head.next;
        }
        int li = 0, hi = nodes.size() - 1;
        while (li < hi) {
            nodes.get(li++).next = nodes.get(hi);
            nodes.get(hi--).next = nodes.get(li);
        }
        nodes.get(li).next = null;
    }

    public static ListNode generate(int[] nums) {
        ListNode res = null;
        for (int i = nums.length - 1; i >= 0; i--)
            res = new ListNode(nums[i], res);
        return res;
    }
}
