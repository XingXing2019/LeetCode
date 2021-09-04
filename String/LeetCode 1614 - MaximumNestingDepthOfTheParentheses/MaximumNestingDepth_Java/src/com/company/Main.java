package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maxDepth(String s) {
        int left = 0, maxDepth = 0;
        for (Character c : s.toCharArray()) {
            if (c == '(') {
                left++;
                maxDepth = Math.max(maxDepth, left);
            } else if (c == ')')
                left--;
        }
        return maxDepth;
    }
}
