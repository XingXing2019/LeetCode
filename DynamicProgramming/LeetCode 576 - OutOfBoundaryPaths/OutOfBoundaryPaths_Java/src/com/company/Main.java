package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int findPaths(int m, int n, int maxMove, int startRow, int startColumn) {
        long[][] dp = new long[m][n];
        long mod = 1_000_000_000 + 7;
        while (maxMove != 0) {
            long[][] temp = new long[m][n];
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    temp[i][j] += i == 0 ? 1 : dp[i - 1][j] % mod;
                    temp[i][j] += i == m - 1 ? 1 : dp[i + 1][j] % mod;
                    temp[i][j] += j == 0 ? 1 : dp[i][j - 1] % mod;
                    temp[i][j] += j == n - 1 ? 1 : dp[i][j + 1] % mod;
                }
            }
            dp = temp;
            maxMove--;
        }
        return (int) (dp[startRow][startColumn] % mod);
    }
}
