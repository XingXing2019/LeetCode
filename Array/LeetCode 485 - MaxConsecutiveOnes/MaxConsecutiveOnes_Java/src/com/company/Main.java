package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int findMaxConsecutiveOnes(int[] nums) {
        int res = 0, count = 0;
        for (int i = 0; i < nums.length; i++) {
            if(nums[i] == 1)
                count++;
            else {
                res = Math.max(res, count);
                count = 0;
            }
        }
        res = Math.max(res, count);
        return res;
    }
}
