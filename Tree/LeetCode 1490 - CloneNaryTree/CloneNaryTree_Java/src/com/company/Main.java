package com.company;

import com.sun.source.tree.Tree;

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.List;
import java.util.TreeMap;

class Node {
    public int val;
    public List<Node> children;


    public Node() {
        children = new ArrayList<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new ArrayList<Node>();
    }

    public Node(int _val, ArrayList<Node> _children) {
        val = _val;
        children = _children;
    }
}

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public Node cloneTree_bfs(Node root) {
        if(root == null) return null;
        Node clone = new Node(root.val);
        ArrayDeque<Node> queue = new ArrayDeque<>(){{offer(root);}};
        ArrayDeque<Node> cloneQueue = new ArrayDeque<>(){{offer(clone);}};
        while (!queue.isEmpty()){
            int count = queue.size();
            for (int i = 0; i < count; i++) {
                Node cur = queue.poll();
                Node cloneCur = cloneQueue.poll();
                for (Node child : cur.children){
                    if(child == null) continue;
                    Node cloneChild = new Node(child.val);
                    cloneCur.children.add(cloneChild);
                    queue.offer(child);
                    cloneQueue.offer(cloneChild);
                }
            }
        }
        return clone;
    }

    public Node cloneTree_dfs(Node root) {
        if(root == null) return null;
        Node clone = new Node(root.val);
        for (Node child : root.children)
            clone.children.add(cloneTree_dfs(child));
        return clone;
    }
}
