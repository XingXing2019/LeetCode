package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        String[] words = {"bqtmbnugq","bjqtmbnuwsgq","m","hkgszenh","zmucnwn","kgzn","yjmk"};
        System.out.println(longestStrChain(words));
    }

    public static int longestStrChain(String[] words) {
        Arrays.sort(words, (a, b) -> a.length() - b.length());
        int[] dp = new int[words.length];
        dp[0] = 1;
        int res = 1;
        for (int i = 1; i < dp.length; i++) {
            int max = 1;
            for (int j = i - 1; j >= 0; j--) {
                if (dp[j] + 1 <= max) continue;
                if (isPredecessor(words[j], words[i]))
                    max = Math.max(max, dp[j] + 1);
            }
            dp[i] = max;
            res = Math.max(res, dp[i]);
        }
        return res;
    }

    public static boolean isPredecessor(String s1, String s2) {
        if (s1.length() + 1 != s2.length()) return false;
        int p1 = 0, p2 = 0, count = 0;
        while (p1 < s1.length() && p2 < s2.length()) {
            if (s1.charAt(p1) == s2.charAt(p2))
                p1++;
            else {
                if (count == 1) return false;
                count++;
            }
            p2++;
        }
        return true;
    }
}
