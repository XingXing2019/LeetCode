package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {0,1,2};
        System.out.println(arrayNesting(nums));
    }


    public static int arrayNesting(int[] nums) {
        int res = 0;
        int[] cache = new int[nums.length];
        boolean[] visited = new boolean[nums.length];
        for (int i = 0; i < nums.length; i++)
            res = Math.max(res, dfs(nums, i, cache, visited));
        return res;
    }

    public static int dfs(int[] nums, int start, int[] cache, boolean[] visited) {
        if (visited[start])
            return cache[start];
        visited[start] = true;
        int res = 1;
        res += dfs(nums, nums[start], cache, visited);
        cache[start] = res;
        return res;
    }
}
