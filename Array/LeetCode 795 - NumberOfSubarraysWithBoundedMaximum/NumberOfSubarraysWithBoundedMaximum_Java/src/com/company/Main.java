package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        int[] nums = {2, 1, 4, 3, 1, 3};
        int left = 2, right = 3;
        System.out.println(numSubarrayBoundedMax(nums, left, right));
    }

    public static int numSubarrayBoundedMax(int[] nums, int left, int right) {
        int[] dp = new int[nums.length];
        int pre = -1, res = 0;
        for (int i = 0; i < dp.length; i++) {
            if (nums[i] < left && i > 0)
                dp[i] = dp[i - 1];
            else if (left <= nums[i] && nums[i] <= right)
                dp[i] = i - pre;
            else if (nums[i] > right) {
                dp[i] = 0;
                pre = i;
            }
            res += dp[i];
        }
        return res;
    }
}
