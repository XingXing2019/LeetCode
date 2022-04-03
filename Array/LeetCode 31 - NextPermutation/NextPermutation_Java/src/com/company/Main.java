package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] nums = {5, 4, 7, 5, 3, 2};
        nextPermutation(nums);
    }

    public static void nextPermutation(int[] nums) {
        int p1 = -1, p2 = -1;
        for (int i = nums.length - 1; i >= 0; i--) {
            for (int j = i - 1; j >= 0; j--) {
                if (nums[j] >= nums[i] || j <= p2) continue;
                p1 = i;
                p2 = j;
            }
        }
        if (p1 == -1) {
            Arrays.sort(nums);
            return;
        }
        int temp = nums[p1];
        nums[p1] = nums[p2];
        nums[p2] = temp;
        Arrays.sort(nums, p2 + 1, nums.length);
    }
}
