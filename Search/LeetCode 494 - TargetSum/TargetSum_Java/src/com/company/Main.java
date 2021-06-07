package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1, 1, 1, 1};
        System.out.println(findTargetSumWays_dp(nums, 3));
    }

    public int findTargetSumWays_dp(int[] nums, int target) {

    }

    int res = 0;
    public int findTargetSumWays_dfs(int[] nums, int S) {
        dfs(nums, 0, S);
        return res;
    }

    public void dfs(int[] nums, int index, int S) {
        if (index == nums.length) {
            if (S == 0)
                res++;
        } else {
            dfs(nums, index + 1, S + nums[index]);
            dfs(nums, index + 1, S - nums[index]);
        }
    }
    
    
}
