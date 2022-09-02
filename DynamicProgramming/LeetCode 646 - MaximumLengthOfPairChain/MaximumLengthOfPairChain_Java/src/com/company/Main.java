package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int findLongestChain(int[][] pairs) {
        Arrays.sort(pairs, (a, b) -> a[0] - b[0]);
        int[] dp = new int[pairs.length];
        dp[0] = 1;
        for (int i = 1; i < pairs.length; i++) {
            var max = 1;
            for (int j = 0; j < i; j++) {
                if (pairs[j][1] >= pairs[i][0]) continue;
                max = Math.max(max, dp[j] + 1);
            }
            dp[i] = max;
        }
        return dp[dp.length - 1];
    }
}
