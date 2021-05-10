package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int countPrimes(int n) {
        boolean[] dp = new boolean[n];
        for (int i = 2; i < dp.length; i++)
            dp[i] = true;
        int res = 0;
        for (int i = 2; i < dp.length; i++) {
            if (!dp[i])
                continue;
            else
                res++;
            for (int j = i + i; j < dp.length; j += i)
                dp[j] = false;
        }
        return res;
    }
}
