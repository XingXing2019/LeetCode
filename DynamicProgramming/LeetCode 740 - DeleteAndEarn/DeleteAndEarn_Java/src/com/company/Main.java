package com.company;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int deleteAndEarn(int[] nums) {
        int max = 0;
        Map<Integer, Integer> map = new HashMap<>();
        for (int num : nums){
            max = Math.max(max, num);
            map.put(num, map.getOrDefault(num, 0) + 1);
        }
        int[] dp = new int[max + 1];
        dp[1] = map.getOrDefault(1, 0);
        for (int i = 2; i < dp.length; i++)
            dp[i] = Math.max(dp[i - 1], dp[i - 2] + i * map.getOrDefault(i, 0));
        return dp[max];
    }
}
