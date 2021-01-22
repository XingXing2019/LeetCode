package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] smallerNumbersThanCurrent(int[] nums) {
        var max = 0;
        for (int num : nums)
            max = Math.max(max, num);
        int[] record = new int[max + 1];
        for (int num : nums)
            record[num]++;
        int[] smaller = new int[max + 1];
        for (int i = 1; i < smaller.length; i++)
            smaller[i] = smaller[i - 1] + record[i - 1];
        for (int i = 0; i < nums.length; i++)
            nums[i] = smaller[nums[i]];
        return nums;
    }
}
