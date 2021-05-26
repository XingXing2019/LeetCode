package com.company;

import java.util.ArrayDeque;
import java.util.Queue;
import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public String reverseParentheses(String s) {
        Stack<Integer> stack = new Stack<>();
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == ')') {
                Queue<Integer> temp = new ArrayDeque<>();
                while (!stack.isEmpty() && s.charAt(stack.peek()) != '(')
                    temp.offer(stack.pop());
                stack.pop();
                while (!temp.isEmpty())
                    stack.push(temp.poll());
            } else
                stack.push(i);
        }
        String res = "";
        while (!stack.isEmpty())
            res = s.charAt(stack.pop()) + res;
        return res;
    }
}
