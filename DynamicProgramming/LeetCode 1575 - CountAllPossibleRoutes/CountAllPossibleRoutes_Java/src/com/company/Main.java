package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] locations = {2,3,6,8};
        int start = 1, finish = 3, fuel = 5;
        System.out.println(countRoutes(locations, start, finish, fuel));
    }

    public static int countRoutes(int[] locations, int start, int finish, int fuel) {
        var dp = new int[locations.length][fuel + 1];
        var mod = 1_000_000_000 + 7;
        for (int i = 0; i < dp.length; i++)
            Arrays.fill(dp[i], -1);
        return dfs(locations, start, finish, fuel, mod, dp);
    }

    public static int dfs(int[] locations, int start, int finish, int fuel, int mod, int[][] dp)
    {
        var res = 0;
        if (dp[start][fuel] != -1) return dp[start][fuel];
        if (start == finish) res = (res + 1) % mod;
        for (int i = 0; i < locations.length; i++)
        {
            var consume = Math.abs(locations[start] - locations[i]);
            if (i == start || fuel < consume) continue;
            res = (res + dfs(locations, i, finish, fuel - consume, mod, dp)) % mod;
        }
        dp[start][fuel] = res;
        return res;
    }
}
