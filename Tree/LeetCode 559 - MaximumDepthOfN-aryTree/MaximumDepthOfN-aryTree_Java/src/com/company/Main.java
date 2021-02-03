package com.company;

class Node {
    public int val;
    public List<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int maxDepth(Node root) {
        int max = 0;
        if(root == null) return 0;
        for(Node child : root.children)
            max = Math.max(max, maxDepth(child));
        return max + 1;
    }

}
