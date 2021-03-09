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

    public static String removeDuplicates(String s, int k) {
        Stack<int[]> stack = new Stack<>();
        for (Character l : s.toCharArray()){
            if(stack.isEmpty() || l != stack.peek()[0])
                stack.push(new int[]{l, 1});
            else
                stack.push(new int[]{l, stack.peek()[1] + 1});
            if(stack.peek()[1] == k){
                for (int i = 0; i < k; i++)
                    stack.pop();
            }
        }
        String res = "";
        while (!stack.isEmpty())
            res = (char)stack.pop()[0] + res;
        return res;
    }
}
