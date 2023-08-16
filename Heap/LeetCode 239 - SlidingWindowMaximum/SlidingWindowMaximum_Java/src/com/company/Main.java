package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int[] maxSlidingWindow(int[] nums, int k) {
        int[] leftMax = new int[nums.length];
        int[] rightMax = new int[nums.length];
        int left = 0, right = 0;
        for (int i = 0; i < nums.length; i++) {
            left = i % k == 0 ? nums[i] : Math.max(left, nums[i]);
            leftMax[i] = left;
        }
        for (int i = nums.length - 1; i >= 0; i--) {
            right = (i + 1) % k == 0 ? nums[i] : Math.max(right, nums[i]);
            rightMax[i] = right;
        }
        int[] res = new int[nums.length - k + 1];
        for (int i = 0; i < res.length; i++)
            res[i] = Math.max(rightMax[i], leftMax[i + k - 1]);
        return res;
    }
}
