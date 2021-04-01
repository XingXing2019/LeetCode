package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int largestUniqueNumber(int[] A) {
        int[] nums = new int[1001];
        for (int a : A)
            nums[a]++;
        for (int i = nums.length - 1; i >= 0; i--) {
            if(nums[i] == 1)
                return i;
        }
        return -1;
    }
}
