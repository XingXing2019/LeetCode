package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int minDistance(String word1, String word2) {
        if (word1.length() == 0 || word2.length() == 0)
            return Math.max(word1.length(), word2.length());
        int[][] dp = new int[word1.length()][word2.length()];
        for (int i = 0; i < word1.length(); i++) {
            for (int j = 0; j < word2.length(); j++) {
                boolean isSame = word1.charAt(i) == word2.charAt(j);
                if (i == 0 && j == 0)
                    dp[i][j] = isSame ? 0 : 1;
                else if(i == 0)
                    dp[i][j] = isSame ? j : dp[0][j - 1] + 1;
                else if (j == 0)
                    dp[i][j] = isSame ? i : dp[i - 1][0] + 1;
                else
                    dp[i][j] = isSame ? dp[i - 1][j - 1] : Math.min(dp[i - 1][j - 1], Math.min(dp[i - 1][j], dp[i][j - 1])) + 1;
            }
        }
        return dp[word1.length() - 1][word2.length() - 1];
    }
}
