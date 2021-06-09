package com.company;

import java.util.PriorityQueue;

public class Main {

    public static void main(String[] args) {
	    int[] nums = {1,-1,-2,4,-7,3};
	    int k = 2;
	    System.out.println(maxResult(nums, k));
    }
    public static int maxResult(int[] nums, int k) {
        int[] dp = new int[nums.length];
        dp[0] = nums[0];
        PriorityQueue<int[]> maxHeap = new PriorityQueue<>((a, b) -> b[0] - a[0]);
        maxHeap.offer(new int[]{nums[0], 0});
        for (int i = 1; i < dp.length; i++) {
            dp[i] = maxHeap.peek()[0] + nums[i];
            maxHeap.offer(new int[]{dp[i], i});
            while (maxHeap.peek()[1] <= i - k)
                maxHeap.poll();
        }
        return dp[dp.length - 1];
    }
}
