package com.company;

public class Main {

    public static void main(String[] args) {
	    int n = 6, delay = 2, forget = 4;
        System.out.println(peopleAwareOfSecret(n, delay, forget));
    }

    public static int peopleAwareOfSecret(int n, int delay, int forget) {
        long[] dp = new long[n + 1];
        dp[1] = 1;
        long share = 0, res = 0, mod = 1_000_000_000 + 7;
        for (int i = 2; i < dp.length; i++) {
            share += i - delay >= 0 ? dp[i - delay] : 0;
            share -= i - forget >= 0? dp[i - forget] : 0;
            dp[i] = share % mod;
        }
        for (int i = dp.length - 1; i >= dp.length - forget; i--)
            res = (res + dp[i]) % mod;
        return (int) (res % mod);
    }
}
