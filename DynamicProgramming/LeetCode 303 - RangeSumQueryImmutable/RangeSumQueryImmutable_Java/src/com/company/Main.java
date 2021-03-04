package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
}

class NumArray {

    int[] prefix;
    public NumArray(int[] nums) {
        prefix = new int[nums.length];
        for (int i = 0; i < nums.length; i++) {
            prefix[i] = i == 0 ? nums[i] : prefix[i - 1] + nums[i];
        }
    }

    public int sumRange(int i, int j) {
        return i == 0 ? prefix[j] : prefix[j] - prefix[i - 1];
    }
}
