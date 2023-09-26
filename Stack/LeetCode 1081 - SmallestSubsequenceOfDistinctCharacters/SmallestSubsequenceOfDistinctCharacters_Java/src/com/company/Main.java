package com.company;

import java.util.HashSet;
import java.util.Stack;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public String smallestSubsequence(String s) {
        int[] freq = new int[26];
        HashSet<Character> seen = new HashSet<>();
        Stack<Character> stack = new Stack<>();
        for (int i = 0; i < s.length(); i++)
            freq[s.charAt(i) - 'a']++;
        for (Character l : s.toCharArray()) {
            freq[l - 'a']--;
            if (seen.contains(l)) continue;
            while (!stack.isEmpty() && l < stack.peek() && freq[stack.peek() - 'a'] != 0)
                seen.remove(stack.pop());
            seen.add(l);
            stack.push(l);
        }
        String res = "";
        while (!stack.isEmpty())
            res = stack.pop() + res;
        return res;
    }
}
