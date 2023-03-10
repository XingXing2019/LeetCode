package com.company;

import java.util.Random;

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

class Solution {
    Random _random;
    ListNode _head;

    public Solution(ListNode head) {
        _random = new Random();
        _head = head;
    }

    public int getRandom() {
        ListNode point = _head;
        int count = 0, res = 0;
        while (point != null) {
            if (_random.nextInt(count + 1) == 0)
                res = point.val;
            count++;
            point = point.next;
        }
        return res;
    }
}


public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}
