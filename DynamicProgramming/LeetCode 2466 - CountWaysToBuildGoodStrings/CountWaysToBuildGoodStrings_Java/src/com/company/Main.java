package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int countGoodStrings(int low, int high, int zero, int one) {
        long res = 0, mod = 1_000_000_000 + 7;
        long[] dp = new long[high + 1];
        dp[0] = 1;
        for (int i = 0; i < dp.length; i++) {
            dp[i] += i - zero >= 0 ? dp[i - zero] % mod  : 0;
            dp[i] += i - one >= 0 ? dp[i - one] % mod : 0;
        }
        for (int i = low; i <= high; i++)
            res += dp[i] % mod;
        return (int)(res % mod);
    }
}
