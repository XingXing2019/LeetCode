package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minDistance(String word1, String word2) {
        int[][] dp = new int[word1.length()][word2.length()];
        dp[0][0] = word1.charAt(0) == word2.charAt(0) ? 1 : 0;
        for (int i = 1; i < dp.length; i++)
            dp[i][0] = word1.charAt(i) == word2.charAt(0) ? 1 : dp[i - 1][0];
        for (int i = 1; i < dp[0].length; i++)
            dp[0][i] = word1.charAt(0) == word2.charAt(i) ? 1 : dp[0][i - 1];
        for (int i = 1; i < dp.length; i++) {
            for (int j = 1; j < dp[0].length; j++) {
                if (word1.charAt(i) == word2.charAt(j))
                    dp[i][j] = dp[i - 1][j - 1] + 1;
                else
                    dp[i][j] = Math.max(dp[i - 1][j], dp[i][j - 1]);
            }
        }
        return word1.length() + word2.length() - 2 * dp[dp.length - 1][dp[0].length - 1];
    }
}
