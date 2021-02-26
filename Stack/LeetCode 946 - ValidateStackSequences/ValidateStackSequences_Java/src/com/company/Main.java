package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean validateStackSequences(int[] pushed, int[] popped) {
        Stack<Integer> stack = new Stack<>();
        int p1 = 0, p2 = 0;
        while (p1 < pushed.length && p2 < popped.length){
            stack.push(pushed[p1++]);
            while (!stack.isEmpty() && popped[p2] == stack.peek()){
                stack.pop();
                p2++;
            }
        }
        return stack.isEmpty() && p2 == popped.length;
    }
}
