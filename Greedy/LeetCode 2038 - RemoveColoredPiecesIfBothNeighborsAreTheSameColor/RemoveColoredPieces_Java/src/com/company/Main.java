package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean winnerOfGame(String colors) {
        return count(colors, 'A') > count(colors, 'B');
    }

    public int count(String colors, Character c) {
        StringBuilder sb = new StringBuilder();
        int res = 0;
        for (int i = 0; i < colors.length(); i++) {
            int len = sb.length();
            if (len > 1 && colors.charAt(i) == c && sb.charAt(len - 1) == c && sb.charAt(len - 2) == c) {
                res++;
                sb.deleteCharAt(len - 1);
            }
            sb.append(colors.charAt(i));
        }
        return res;
    }
}
