package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int lengthOfLIS(int[] nums) {
        int[] dp = new int[nums.length];
        int res = 1;
        Arrays.fill(dp, 1);
        for (int i = 1; i < dp.length; i++) {
            int max = 0;
            for (int j = i - 1; j >= 0; j--) {
                if (nums[i] <= nums[j]) continue;
                max = Math.max(max, dp[j]);
            }
            dp[i] += max;
            res = Math.max(res, dp[i]);
        }
        return res;
    }
}
