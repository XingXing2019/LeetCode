package com.company;

import java.util.ArrayDeque;
import java.util.Queue;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class MyStack {
    Queue<Integer> stack;
    public MyStack() {
        stack = new ArrayDeque<>();
    }

    public void push(int x) {
        Queue<Integer> temp = new ArrayDeque<>();
        while (!stack.isEmpty())
            temp.offer(stack.poll());
        stack.offer(x);
        while (!temp.isEmpty())
            stack.offer(temp.poll());
    }

    public int pop() {
        return stack.poll();
    }

    public int top() {
        return stack.peek();
    }

    public boolean empty() {
        return stack.isEmpty();
    }
}
