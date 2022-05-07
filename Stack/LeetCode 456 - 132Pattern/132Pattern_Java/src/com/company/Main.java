package com.company;

import java.util.TreeSet;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean find132pattern(int[] nums) {
        int[] leftMin = new int[nums.length], rightMax = new int[nums.length];
        int min = Integer.MAX_VALUE;
        for (int i = 0; i < nums.length; i++) {
            leftMin[i] = min;
            min = Math.min(min, nums[i]);
        }
        TreeSet<Integer> set = new TreeSet<>();
        for (int i = nums.length - 1; i >= 0; i--) {
            Integer smallest = set.lower(nums[i]);
            set.add(nums[i]);
            rightMax[i] = smallest == null ? Integer.MIN_VALUE : smallest;
        }
        for (int i = 0; i < nums.length; i++) {
            if (leftMin[i] < rightMax[i])
                return true;
        }
        return false;
    }
}
