package com.company;

public class Main {

    public static void main(String[] args) {
	    int target = 7;
	    int[] nums = {2, 3, 1, 2, 4, 3};
        System.out.println(minSubArrayLen(target, nums));
    }

    public static int minSubArrayLen(int target, int[] nums) {
        int li = 0, hi = 0, sum = 0, res = Integer.MAX_VALUE;
        while (hi < nums.length) {
            sum += nums[hi];
            while (sum >= target) {
                res = Math.min(res, hi - li + 1);
                sum -= nums[li++];
            }
            hi++;
        }
        return res == Integer.MAX_VALUE ? 0 : res;
    }
}
