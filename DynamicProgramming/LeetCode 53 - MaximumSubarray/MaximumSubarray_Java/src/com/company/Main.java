package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int maxSubArray(int[] nums) {
        var res = nums[0];
        for (int i = 1; i < nums.length; i++) {
            nums[i] = Math.max(nums[i], nums[i] + nums[i - 1]);
            res = Math.max(res, nums[i]);
        }
        return res;
    }
}
