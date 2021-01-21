package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] runningSum(int[] nums) {
        for (int i = 1; i < nums.length; i++) {
            nums[i] += nums[i - 1];
        }
        return nums;
    }
}
