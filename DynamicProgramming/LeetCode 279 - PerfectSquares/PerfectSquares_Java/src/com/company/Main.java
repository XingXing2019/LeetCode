package com.company;

public class Main {

    public static void main(String[] args) {
        int n = 12;
        System.out.println(numSquares(n));
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
}
