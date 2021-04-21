package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int numDecodings(String s) {
        if (s.charAt(0) == '0') return 0;
        int[] dp = new int[s.length()];
        dp[0] = 1;
        for (int i = 1; i < s.length(); i++) {
            int num = Integer.parseInt(s.substring(i - 1, i + 1));
            if (s.charAt(i) == '0') {
                if (num == 0 || num > 26) return 0;
                dp[i] = i == 1 ? 1 : dp[i - 2];
            } else if (num < 10 || num > 26)
                dp[i] = dp[i - 1];
            else
                dp[i] = i == 1 ? dp[i - 1] + 1 : dp[i - 1] + dp[i - 2];
        }
        return dp[s.length() - 1];
    }
}
