package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1, 1, 2, 2, 3, 3};
        int k = 3;
        isPossibleDivide(nums, k);
    }

    public static boolean isPossibleDivide(int[] nums, int k) {
        if (nums.length % k != 0) return false;
        int max = Arrays.stream(nums).max().getAsInt();
        int[] record = new int[max + 1];
        for (int num : nums)
            record[num]++;
        for (int i = 0; i < record.length; i++) {
            if (record[i] == 0) continue;
            int count = record[i];
            for (int j = 0; j < k; j++) {
                if(i + j >= record.length || record[i + j] - count < 0) return false;
                record[i + j] -= count;
            }
        }
        return true;
    }
}
