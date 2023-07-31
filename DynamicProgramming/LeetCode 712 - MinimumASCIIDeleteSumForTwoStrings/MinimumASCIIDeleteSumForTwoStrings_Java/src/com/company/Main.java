package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int minimumDeleteSum(String s1, String s2) {
        int[][] dp = new int[s1.length()][s2.length()];
        dp[0][0] = s1.charAt(0) == s2.charAt(0) ? s1.charAt(0) : 0;
        for (int i = 1; i < s1.length(); i++)
            dp[i][0] = s1.charAt(i) == s2.charAt(0) ? s1.charAt(i) : dp[i - 1][0];
        for (int i = 1; i < s2.length(); i++)
            dp[0][i] = s1.charAt(0) == s2.charAt(i) ? s2.charAt(i) : dp[0][i - 1];
        for (int i = 1; i < s1.length(); i++) {
            for (int j = 1; j < s2.length(); j++) {
                dp[i][j] = s1.charAt(i) == s2.charAt(j) ? dp[i - 1][j - 1] + s1.charAt(i) : Math.max(dp[i - 1][j], dp[i][j - 1]);
            }
        }
        int res = 0;
        for (int i = 0; i < s1.length(); i++)
            res += s1.charAt(i);
        for (int i = 0; i < s2.length(); i++)
            res += s2.charAt(i);
        return res - 2 * dp[s1.length() - 1][s2.length() - 1];
    }
}
