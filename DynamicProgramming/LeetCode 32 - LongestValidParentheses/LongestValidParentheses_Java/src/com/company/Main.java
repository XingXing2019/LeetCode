package com.company;

import java.util.Arrays;
import java.util.Collections;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int longestValidParentheses(String s) {
        var sb = new StringBuilder();
        for (int i = s.length() - 1; i >= 0; i--)
            sb.append(s.charAt(i));
        return Math.max(count(s, false), count(sb.toString(), true));
    }

    public int count(String s, boolean isReverse) {
        int left = 0, right = 0, res = 0;
        for (int i = 0; i < s.length(); i++) {
            if (s.charAt(i) == '(') left++;
            else right++;
            if (!isReverse && right > left || isReverse && left > right) {
                left = 0;
                right = 0;
            } else if (left == right)
                res = Math.max(res, left + right);
        }
        return res;
    }
}
