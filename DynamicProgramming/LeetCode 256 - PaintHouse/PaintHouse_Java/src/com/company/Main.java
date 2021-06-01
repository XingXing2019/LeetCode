package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minCost(int[][] costs) {
        int[][] dp = new int[costs.length][3];
        int res = Integer.MAX_VALUE;
        for (int i = 0; i < dp.length; i++) {
            dp[i][0] = i == 0 ? costs[i][0] : Math.min(dp[i - 1][1], dp[i - 1][2]) + costs[i][0];
            dp[i][1] = i == 0 ? costs[i][1] : Math.min(dp[i - 1][0], dp[i - 1][2]) + costs[i][1];
            dp[i][2] = i == 0 ? costs[i][2] : Math.min(dp[i - 1][0], dp[i - 1][1]) + costs[i][2];
            if (i == dp.length - 1)
                res = Math.min(dp[i][0], Math.min(dp[i][1], dp[i][2]));
        }
        return res;
    }
}
