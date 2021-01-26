package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int trap(int[] height) {
        int left = 0, right  = 0, res = 0;
        int[] leftMax = new int[height.length];
        int[] rightMax = new int[height.length];
        for (int i = 0; i < height.length; i++) {
            leftMax[i] = left;
            left = Math.max(left, height[i]);
            rightMax[height.length - i - 1] = right;
            right = Math.max(right, height[height.length - i - 1]);
        }
        for (int i = 0; i < height.length; i++)
            res += Math.max(0, Math.min(leftMax[i], rightMax[i]) - height[i]);
        return res;
    }
}
