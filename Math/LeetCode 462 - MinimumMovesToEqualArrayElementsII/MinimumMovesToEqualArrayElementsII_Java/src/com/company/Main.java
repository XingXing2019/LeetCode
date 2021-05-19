package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int minMoves2(int[] nums) {
        Arrays.sort(nums);
        int mid = nums[nums.length / 2], res = 0;
        for (int num : nums)
            res += Math.abs(num - mid);
        return res;
    }
}
