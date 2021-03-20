package com.company;

import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        String[] token = {"2","1","+","3","*"};
        System.out.println(evalRPN(token));
    }

    public static int evalRPN(String[] tokens) {
        Stack<Integer> stack = new Stack<>();
        for (String t : tokens) {
            if (t.equals("+")) {
                stack.push(stack.pop() + stack.pop());
            } else if (t.equals("-")) {
                stack.push(-stack.pop() + stack.pop());
            } else if (t.equals("*")) {
                stack.push(stack.pop() * stack.pop());
            } else if (t.equals("/")) {
                int temp = stack.pop();
                stack.push(stack.pop() / temp);
            } else
                stack.push(Integer.parseInt(t));
        }
        int res = 0;
        while (!stack.isEmpty())
            res += stack.pop();
        return res;
    }
}
