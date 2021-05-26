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

    public String reverseParentheses_index(String s) {
        Stack<Integer> stack = new Stack<>();
        char[] letters = s.toCharArray();
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == '(')
                stack.push(i);
            else if (s.charAt(i) == ')')
                reverse(letters, stack.pop(), i);
        }
        StringBuilder res = new StringBuilder();
        for (Character l : letters) {
            if (l != '(' && l != ')')
                res.append(l);
        }
        return res.toString();
    }

    public void reverse(char[] letters, int li, int hi) {
        while (li < hi) {
            Character temp = letters[hi];
            letters[hi--] = letters[li];
            letters[li++] = temp;
        }
    }
}
