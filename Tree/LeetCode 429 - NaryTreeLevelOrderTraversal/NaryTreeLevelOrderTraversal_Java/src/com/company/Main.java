package com.company;

import com.sun.source.tree.Tree;

import java.util.ArrayDeque;
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
    public List<List<Integer>> levelOrder(Node root) {
        List<List<Integer>> res = new ArrayList<>();
        if(root == null) return res;
        ArrayDeque<Node> queue = new ArrayDeque<>(){{offer(root);}};
        while (!queue.isEmpty()){
            int count = queue.size();
            List<Integer> temp = new ArrayList<>();
            for (int i = 0; i < count; i++) {
                Node cur = queue.poll();
                temp.add(cur.val);
                for (Node child : cur.children){
                    if(child != null)
                        queue.offer(child);
                }
            }
            res.add(temp);
        }
        return res;
    }
}
