package com.company;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int longestSubarray(int[] nums) {
        int li = 0, hi = 0, zero = 0, res = 0;
        while (hi < nums.length) {
            zero += nums[hi] == 0 ? 1 : 0;
            while (zero > 1) {
                zero -= nums[li] == 0 ? 1 : 0;
                li++;
            }
            res = Math.max(res, hi - li);
            hi++;
        }
        return res;
    }
}