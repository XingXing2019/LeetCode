package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }
}

class MinStack {
    private Stack<Integer> nums;
    private Stack<Integer> min;

    public MinStack() {
        nums = new Stack<>();
        min = new Stack<>();
    }

    public void push(int val) {
        nums.push(val);
        if (min.isEmpty()) {
            min.push(val);
            return;
        }
        min.push(Math.min(val, min.peek()));
    }

    public void pop() {
        nums.pop();
        min.pop();
    }

    public int top() {
        return nums.peek();
    }

    public int getMin() {
        return min.peek();
    }
}
