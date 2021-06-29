package com.company;

public class Main {

    public static void main(String[] args) {
        int[] nums = {0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1};
        int k = 3;
        System.out.println(longestOnes(nums, k));
    }

    public static int longestOnes(int[] nums, int k) {
        int li = 0, hi = 0, zero = 0, res = 0;
        while (hi < nums.length) {
            if (nums[hi] == 0) {
                zero++;
                res = Math.max(res, hi - li);
                while (zero > k)
                    zero -= nums[li++] == 0 ? 1 : 0;
            }
            hi++;
        }
        res = Math.max(res, hi - li);
        return res;
    }
}
