package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int missingNumber(int[] nums) {
        int sum = (1 + nums.length) * nums.length / 2;
        for (int num : nums)
            sum -= num;
        return sum;
    }
}
