package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int countVowelStrings(int n) {
        if (n == 1) return 5;
        int[][] dp = new int[n + 1][5];
        Arrays.fill(dp[1], 1);
        for (int i = 2; i < dp.length; i++) {
            int[] suffix = new int[5];
            suffix[4] = dp[i - 1][4];
            for (int j = 3; j >= 0; j--)
                suffix[j] = suffix[j + 1] + dp[i - 1][j];
            for (int j = 0; j < 5; j++)
                dp[i][j] = suffix[j];
        }
        int res = 0;
        for (int i = 0; i < 5; i++)
            res += dp[n][i];
        return res;
    }
}
