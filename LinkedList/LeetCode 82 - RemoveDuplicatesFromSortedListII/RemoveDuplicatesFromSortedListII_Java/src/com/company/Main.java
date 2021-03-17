package com.company;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

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
    public ListNode deleteDuplicates(ListNode head) {
        List<ListNode> nodes = new ArrayList<>();
        HashSet<Integer> set = new HashSet<>();
        while (head != null) {
            if (set.add(head.val))
                nodes.add(head);
            else if (!nodes.isEmpty() && nodes.get(nodes.size() - 1).val == head.val)
                nodes.remove(nodes.size() - 1);
            head = head.next;
        }
        for (int i = 0; i < nodes.size(); i++)
            nodes.get(i).next = i == nodes.size() - 1 ? null : nodes.get(i + 1);
        return nodes.size() == 0 ? null : nodes.get(0);
    }
}
