package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class MyQueue {
    Stack<Integer> queue;
    public MyQueue() {
        queue = new Stack<>();
    }
    public void push(int x) {
        Stack<Integer> temp = new Stack<>();
        while (!queue.isEmpty())
            temp.push(queue.pop());
        temp.push(x);
        while (!temp.isEmpty())
            queue.push(temp.pop());
    }
    public int pop() {
        return queue.pop();
    }
    public int peek() {
        return queue.peek();
    }
    public boolean empty() {
        return queue.isEmpty();
    }
}
