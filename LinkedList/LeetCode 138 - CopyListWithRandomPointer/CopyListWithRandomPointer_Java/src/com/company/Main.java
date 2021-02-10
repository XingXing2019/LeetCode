package com.company;

import java.util.HashMap;
import java.util.Map;

class Node {
    int val;
    Node next;
    Node random;

    public Node(int val) {
        this.val = val;
        this.next = null;
        this.random = null;
    }
}

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public Node copyRandomList(Node head) {
        Map<Node, Node> map = new HashMap<>();
        Node cloneHead = copyNode(head, map);
        Node point = head, clonePoint = cloneHead;
        while (point != null){
            clonePoint.next = copyNode(point.next, map);
            clonePoint.random = copyNode(point.random, map);
            point = point.next;
            clonePoint = clonePoint.next;
        }
        return cloneHead;
    }
    public Node copyNode(Node node, Map<Node, Node> map){
        if(node == null) return null;
        if(map.containsKey(node)) return map.get(node);
        Node clone = new Node(node.val);
        map.put(node, clone);
        return clone;
    }
}
