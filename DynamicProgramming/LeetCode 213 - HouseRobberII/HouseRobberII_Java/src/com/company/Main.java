package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {2,3,4,5,7,1,2};
        System.out.println(rob(nums));
    }

    public static int rob(int[] nums) {
        if (nums.length < 2) return nums[0];
        int[][] dp = new int[nums.length][2];
        dp[0][0] = nums[0];
        dp[1][0] = nums[0];
        dp[1][1] = nums[1];
        for (int i = 2; i < dp.length; i++) {
            dp[i][0] = i == dp.length - 1 ? dp[i - 1][0] : Math.max(dp[i - 2][0] + nums[i], dp[i - 1][0]);
            dp[i][1] = Math.max(dp[i - 2][1] + nums[i], dp[i - 1][1]);
        }
        return Math.max(dp[dp.length - 1][0], dp[dp.length - 1][1]);
    }
}
