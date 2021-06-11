package com.company;

import java.lang.reflect.Array;
import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int n = 2;
        System.out.println(numSquares_dp(n));
    }

    public static int numSquares(int n) {
        int[] dp = new int[n + 1];
        dp[1] = 1;
        for (int i = 2; i < dp.length; i++) {
            if ((int) Math.sqrt(i) * (int) Math.sqrt(i) == i)
                dp[i] = 1;
            else {
                int min = Integer.MAX_VALUE;
                for (int j = i - 1; j >= i / 2; j--)
                    min = Math.min(min, dp[j] + dp[i - j]);
                dp[i] = min;
            }
        }
        return dp[dp.length - 1];
    }

    public static int numSquares_dp(int n) {
        int[] dp = new int[n + 1];
        Arrays.fill(dp, Integer.MAX_VALUE - 1);
        for (int i = 1; i * i <= n; i++)
            dp[i * i] = 1;
        for (int i = 1; i < dp.length; i++) {
            for (int j = 0; i + j * j <= n; j++)
                dp[i + j * j] = Math.min(dp[i] + 1, dp[i + j * j]);
        }
        return dp[dp.length - 1];
    }
}
