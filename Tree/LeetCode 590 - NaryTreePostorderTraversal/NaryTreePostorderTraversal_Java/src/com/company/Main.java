package com.company;

import java.util.ArrayList;
import java.util.List;

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

    public List<Integer> postorder(Node root) {
        List<Integer> res = new ArrayList<>();
        dfs(root, res);
        return res;
    }

    public void dfs(Node root, List<Integer> nodes) {
        if (root == null) return;
        for (int i = 0; i < root.children.size(); i++)
            dfs(root.children.get(i), nodes);
        nodes.add(root.val);
    }
}
