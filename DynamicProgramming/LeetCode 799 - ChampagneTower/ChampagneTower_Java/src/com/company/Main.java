package com.company;

public class Main {

    public static void main(String[] args) {
        int poured = 234, query_row = 1, query_glass = 1;
        System.out.println(champagneTower(poured, query_row, query_glass));
    }

    public static double champagneTower(int poured, int query_row, int query_glass) {
        double[][] dp = new double[query_row + 1][query_glass + 2];
        dp[0][0] = poured;
        for (int i = 0; i < query_row; i++) {
            for (int j = 0; j < query_glass + 1; j++) {
                double extra = Math.max(0, dp[i][j] - 1);
                dp[i][j] -= extra;
                dp[i + 1][j] += extra / 2;
                dp[i + 1][j + 1] += extra / 2;
            }
        }
        return Math.min(1, dp[query_row][query_glass]);
    }
}
