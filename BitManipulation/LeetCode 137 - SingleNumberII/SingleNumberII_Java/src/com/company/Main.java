package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {2, 2, 3, 2};
        System.out.println(singleNumber(nums));
    }

    public static int singleNumber(int[] nums) {
        int res = 0;
        for (int i = 0; i < 32; i++) {
            int one = 0;
            for (int j = 0; j < nums.length; j++)
                one += (nums[j] >> i) & 1;
            res |= one % 3 << i;
        }
        return res;
    }
}
