package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minCostClimbingStairs(int[] cost) {
        int[] dp = new int[cost.length + 1];
        dp[0] = cost[0];
        dp[1] = cost[1];
        for (int i = 2; i < dp.length; i++) {
            dp[i] = Math.min(dp[i - 1], dp[i - 2]);
            if (i != dp.length - 1) dp[i] += cost[i];
        }
        return dp[dp.length - 1];
    }
}
