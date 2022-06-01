package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int[] maxDepthAfterSplit(String seq) {
        Stack<Integer> a = new Stack<>();
        Stack<Integer> b = new Stack<>();
        var res = new int[seq.length()];
        for (int i = 0; i < seq.length(); i++) {
            if (seq.charAt(i) == '(') {
                if (a.size() <= b.size())
                    a.push(i);
                else
                    b.push(i);
            } else {
                if (a.size() < b.size()) {
                    res[i] = 1;
                    res[b.pop()] = 1;
                } else
                    a.pop();
            }
        }
        return res;
    }
}
