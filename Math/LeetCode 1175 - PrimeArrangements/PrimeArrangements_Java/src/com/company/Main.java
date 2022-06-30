package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int n = 5;
        System.out.println(numPrimeArrangements(n));
    }

    public static int numPrimeArrangements(int n) {
        boolean[] dp = new boolean[n + 1];
        Arrays.fill(dp, true);
        int count = 0;
        for (int i = 2; i < dp.length; i++) {
            for (int j = 2; i * j < dp.length; j++) {
                dp[i * j] = false;
            }
            if (dp[i]) count++;
        }
        long res = 1, mod = 1_000_000_000 + 7;
        for (int i = 1; i <= count; i++)
            res = (res * i) % mod;
        for (int i = 1; i <= n - count; i++)
            res = (res * i) % mod;
        return (int) (res % mod);
    }
}
