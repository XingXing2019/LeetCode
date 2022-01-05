package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int maxCoins(int[] nums) {
        int[][] dp = new int[nums.length][nums.length];
        return dfs(nums, dp, 0, nums.length - 1);
    }

    public int dfs(int[] nums, int[][] dp, int li, int hi) {
        if (li > hi) return 0;
        if (dp[li][hi] != 0) return dp[li][hi];
        int max = 0;
        for (int i = li; i <= hi; i++) {
            var coins = (li == 0 ? 1 : nums[li - 1]) * nums[i] * (hi == nums.length - 1 ? 1 : nums[hi + 1]);
            var cur = dfs(nums, dp, li, i - 1) + coins + dfs(nums, dp, i + 1, hi);
            max = Math.max(max, cur);
        }
        dp[li][hi] = max;
        return max;
    }
}
