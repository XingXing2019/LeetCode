package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class Node{
    public int val;
    public Node[] children;

    public Node(){
        children = new Node[26];
    }
}

class MapSum {
    Node root;
    Map<String, Integer> map;
    public MapSum() {
        root = new Node();
        map = new HashMap<>();
    }

    public void insert(String key, int val) {
        Node pointer = root;
        for (int i = 0; i < key.length(); i++) {
            Character letter = key.charAt(i);
            if(pointer.children[letter - 'a'] == null)
                pointer.children[letter - 'a'] = new Node();
            pointer = pointer.children[letter - 'a'];
            pointer.val = map.containsKey(key) ? pointer.val - map.get(key) + val : pointer.val + val;
        }
        map.put(key, val);
    }

    public int sum(String prefix) {
        Node pointer = root;
        for (int i = 0; i < prefix.length(); i++) {
            Character letter = prefix.charAt(i);
            if(pointer.children[letter - 'a'] == null)
                return 0;
            pointer = pointer.children[letter - 'a'];
        }
        return pointer.val;
    }
}
