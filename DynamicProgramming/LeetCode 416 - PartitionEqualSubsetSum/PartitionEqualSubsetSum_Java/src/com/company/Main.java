package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public boolean canPartition(int[] nums) {
        int sum = 0;
        for (int num : nums)
            sum += num;
        if (sum % 2 != 0) return false;
        Arrays.sort(nums);
        boolean[][] memory = new boolean[nums.length + 1][sum / 2 + 1];
        boolean[][] visited = new boolean[nums.length + 1][sum / 2 + 1];
        return dfs(nums, sum / 2, nums.length - 1, memory, visited);
    }

    public boolean dfs(int[] nums, int target, int index, boolean[][] memory, boolean[][] visited) {
        if (target == 0) return true;
        if (index == 0 || target < 0) return false;
        if (visited[index][target])
            return memory[index][target];
        boolean res = dfs(nums, target - nums[index], index - 1, memory, visited) ||
                dfs(nums, target, index - 1, memory, visited);
        visited[index][target] = true;
        memory[index][target] = res;
        return res;
    }
}
