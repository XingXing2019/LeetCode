package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int combinationSum4(int[] nums, int target) {
        int[] dp = new int[target + 1];
        dp[0] = 1;
        for (int i = 1; i < dp.length; i++) {
            for (int num : nums) {
                if (i - num < 0) continue;
                dp[i] += dp[i - num];
            }
        }
        return dp[target];
    }
}
