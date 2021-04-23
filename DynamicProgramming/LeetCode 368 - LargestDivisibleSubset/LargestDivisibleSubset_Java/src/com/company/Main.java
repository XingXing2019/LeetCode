package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1, 2, 4, 8};
        System.out.println(largestDivisibleSubset(nums));
    }
    public static List<Integer> largestDivisibleSubset(int[] nums) {
        Arrays.sort(nums);
        List<Integer>[] dp = new List[nums.length];
        List<Integer> res = null;
        int max = 0;
        for (int i = 0; i < nums.length; i++) {
            dp[i] = new ArrayList<>();
            dp[i].add(nums[i]);
            int longest = 0, index = -1;
            for (int j = i - 1; j >= 0; j--) {
                if(nums[i] % nums[j] == 0 && dp[j].size() > longest){
                    index = j;
                    longest = dp[j].size();
                }
            }
            if(index != -1) dp[i].addAll(dp[index]);
            if(dp[i].size() > max){
                max = dp[i].size();
                res = dp[i];
            }
        }
        return res;
    }
}
