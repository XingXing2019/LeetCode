package com.company;

import java.util.Stack;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int scoreOfParentheses(String S) {
        char[] letters = S.toCharArray();
        int time = 1, res = 0;
        for (int i = 0; i < letters.length; i++) {
            if (letters[i] == '(')
                time *= 2;
            else {
                if (letters[i - 1] == '(')
                    res += time / 2;
                time /= 2;
            }
        }
        return res;
    }
}
