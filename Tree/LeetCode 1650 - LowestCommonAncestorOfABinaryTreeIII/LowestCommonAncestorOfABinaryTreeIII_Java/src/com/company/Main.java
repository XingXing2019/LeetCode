package com.company;

import java.util.HashSet;

class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public Node lowestCommonAncestor(Node p, Node q) {
        HashSet<Node> ancestors = new HashSet<>();
        while (p != null){
            ancestors.add(p);
            p = p.parent;
        }
        while (q != null){
            if(ancestors.contains(q)) return q;
            q = q.parent;
        }
        return null;
    }
}
