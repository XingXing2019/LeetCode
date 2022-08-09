package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minStartValue(int[] nums) {
        int min = nums[0], prefix = 0;
        for (int num : nums) {
            prefix += num;
            min = Math.min(min, prefix);
        }
        return Math.max(1, 1 - min);
    }
}
