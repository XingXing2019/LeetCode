package com.company;

import java.util.ArrayList;
import java.util.Stack;
import java.util.*;

public class Main {

    public static void main(String[] args) {
        String s = "pbbcggttciiippooaais";
        int k = 2;
        System.out.println(removeDuplicates(s, k));
    }

    public static String removeDuplicates_stack(String s, int k) {
        Stack<int[]> stack = new Stack<>();
        for (Character l : s.toCharArray()) {
            if (stack.isEmpty() || l != stack.peek()[0])
                stack.push(new int[]{l, 1});
            else
                stack.push(new int[]{l, stack.peek()[1] + 1});
            if (stack.peek()[1] == k) {
                for (int i = 0; i < k; i++)
                    stack.pop();
            }
        }
        StringBuilder res = new StringBuilder();
        while (!stack.isEmpty())
            res.append((char) stack.pop()[0]);
        return res.reverse().toString();
    }

    public static String removeDuplicates_linkedList(String s, int k) {
        List<int[]> stack = new LinkedList<>();
        for (Character l : s.toCharArray()) {
            if (stack.isEmpty() || l != stack.get(stack.size() - 1)[0])
                stack.add(new int[]{l, 1});
            else
                stack.add(new int[]{l, stack.get(stack.size() - 1)[1] + 1});
            if (stack.get(stack.size() - 1)[1] == k) {
                for (int i = 0; i < k; i++)
                    stack.remove(stack.size() - 1);
            }
        }
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < stack.size(); i++)
            res.append((char) stack.get(i)[0]);
        return res.toString();
    }
}
