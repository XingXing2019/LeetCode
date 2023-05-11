package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int maxUncrossedLines(int[] nums1, int[] nums2) {
        int[][] dp = new int[nums1.length][nums2.length];
        for (int i = 0; i < nums1.length; i++) {
            for (int j = 0; j < nums2.length; j++) {
                if (i == 0 && j == 0)
                    dp[i][j] = nums1[i] == nums2[j] ? 1 : 0;
                else if (i == 0 && j != 0)
                    dp[i][j] = nums1[i] == nums2[j] ? 1 : dp[i][j - 1];
                else if (i != 0 && j == 0)
                    dp[i][j] = nums1[i] == nums2[j] ? 1 : dp[i - 1][j];
                else
                    dp[i][j] = nums1[i] == nums2[j] ? dp[i - 1][j - 1] + 1 : Math.max(dp[i - 1][j], dp[i][j - 1]);
            }
        }
        return dp[dp.length - 1][dp[0].length - 1];
    }
}
