package com.company;

import java.util.HashSet;
import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        String s = "abacb";
        System.out.println(removeDuplicateLetters(s));
    }

    public static String removeDuplicateLetters(String s) {
        int[] freq = new int[26];
        for (Character c : s.toCharArray())
            freq[c - 'a']++;
        Stack<Character> stack = new Stack<>();
        for (Character c : s.toCharArray()) {
            freq[c - 'a']--;
            if (stack.contains(c)) continue;
            while (!stack.isEmpty() && freq[stack.peek() - 'a'] > 0 && c < stack.peek())
                stack.pop();
            stack.push(c);
        }
        String res = "";
        while (!stack.isEmpty())
            res = stack.pop() + res;
        return res;
    }
}
