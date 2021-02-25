package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int findUnsortedSubarray(int[] nums) {
        int min = Integer.MAX_VALUE, max = Integer.MIN_VALUE;
        int end = 0, start = 0;
        for (int i = 0; i < nums.length; i++) {
            max = Math.max(max, nums[i]);
            if(nums[i] < max) end = i;
            min = Math.min(min, nums[nums.length - i - 1]);
            if(nums[nums.length - i - 1] > min) start = nums.length - i - 1;
        }
        return start == end ? 0 : end - start + 1;
    }
}
