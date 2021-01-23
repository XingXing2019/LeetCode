package com.company;

import java.util.HashMap;
import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        String s = "()[]{}";
        System.out.print(isValid(s));
    }

    public static boolean isValid(String s) {
        HashMap<Character, Character> map = new HashMap<>() {{
            put('(', ')');
            put('[', ']');
            put('{', '}');
        }};
        Stack<Character> stack = new Stack<>();
        for (char l : s.toCharArray()){
            if(stack.empty() || !map.containsKey(stack.peek()) || map.get(stack.peek()) != l)
                stack.push(l);
            else
                stack.pop();
        }
        return stack.empty();
    }
}
