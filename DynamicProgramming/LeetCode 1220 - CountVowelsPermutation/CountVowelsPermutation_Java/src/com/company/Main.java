package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int countVowelPermutation(int n) {
        long[] dp = new long[5];
        long mod = 1_000_000_000 + 7;
        Arrays.fill(dp, 1);
        for (int i = 1; i < n; i++) {
            long[] temp = new long[5];
            temp[0] = dp[1] % mod;
            temp[1] = (dp[0] + dp[2]) % mod;
            temp[2] = (dp[0] + dp[1] + dp[3] + dp[4]) % mod;
            temp[3] = (dp[2] + dp[4]) % mod;
            temp[4] = dp[0] % mod;
            dp = temp;
        }
        long res = 0;
        for (int i = 0; i < dp.length; i++)
            res += dp[i];
        return (int) (res % mod);
    }
}
