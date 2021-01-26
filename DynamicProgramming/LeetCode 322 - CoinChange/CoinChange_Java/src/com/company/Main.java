package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] coins = {1, 2, 5};
        int amount = 11;
        coinChange(coins, amount);
    }

    public static int coinChange(int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        Arrays.fill(dp, -1);
        dp[0] = 0;
        for (int coin : coins){
            if(coin <= amount)
                dp[coin] = 1;
        }
        for (int i = 1; i < dp.length; i++) {
            if(dp[i] != -1) continue;
            int min = Integer.MAX_VALUE;
            for (int coin : coins){
                if(i - coin < 0 || dp[i - coin] == -1) continue;
                min = Math.min(min, dp[i - coin] + 1);
            }
            dp[i] = min == Integer.MAX_VALUE ? -1 : min;
        }
        return dp[amount];
    }
}
