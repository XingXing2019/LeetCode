package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean isInterleave(String s1, String s2, String s3) {
        if (s1.length() + s2.length() != s3.length())
            return false;
        boolean[][] dp = new boolean[s2.length() + 1][s1.length() + 1];
        dp[0][0] = true;
        for (int i = 1; i < s1.length() + 1; i++)
            dp[0][i] = dp[0][i - 1] && s1.charAt(i - 1) == s3.charAt(i - 1);
        for (int i = 1; i < s2.length() + 1; i++)
            dp[i][0] = dp[i - 1][0] && s2.charAt(i - 1) == s3.charAt(i - 1);
        for (int i = 1; i < dp.length; i++) {
            for (int j = 1; j < dp[0].length; j++) {
                char expected = s3.charAt(i + j - 1);
                if (dp[i - 1][j] && dp[i][j - 1])
                    dp[i][j] = s2.charAt(i - 1) == expected || s1.charAt(j - 1) == expected;
                else if (dp[i - 1][j])
                    dp[i][j] = s2.charAt(i - 1) == expected;
                else if (dp[i][j - 1])
                    dp[i][j] = s1.charAt(j - 1) == expected;
            }
        }
        return dp[s2.length()][s1.length()];
    }
}
