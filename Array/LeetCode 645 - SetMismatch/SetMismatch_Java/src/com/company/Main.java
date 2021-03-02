package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int[] findErrorNums(int[] nums) {
        int sum = (1 + nums.length) * nums.length / 2;
        int[] res = new int[2];
        for (int i = 0; i < nums.length; i++) {
            if (nums[Math.abs(nums[i]) - 1] < 0) res[0] = Math.abs(nums[i]);
            else sum -= Math.abs(nums[i]);
            nums[Math.abs(nums[i]) - 1] *= -1;
        }
        res[1] = sum;
        return res;
    }
}
