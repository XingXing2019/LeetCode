package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	int[][] workers = {{0, 0}, {2, 1}};
	int[][] bikes = {{1, 2}, {3, 3}};
        System.out.println(assignBikes(workers, bikes));
    }

    public static int assignBikes(int[][] workers, int[][] bikes) {
        int[] dp = new int[1 << bikes.length];
        Arrays.fill(dp, -1);
        return dfs(workers, bikes, 0, 0, dp);
    }

    public static int dfs(int[][] workers, int[][] bikes, int index, int state, int[] dp) {
        if (index == workers.length) return 0;
        if (dp[state] != -1) return dp[state];
        int res = 1_000_000;
        for (int i = 0; i < bikes.length; i++) {
            if ((state & (1 << i)) != 0) continue;
            int dis = Math.abs(bikes[i][0] - workers[index][0]) + Math.abs(bikes[i][1] - workers[index][1]);
            res = Math.min(res, dis + dfs(workers, bikes, index + 1, state | (1 << i), dp));
        }
        return dp[state] = res;
    }
}
