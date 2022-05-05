package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        int li = 0, hi = 0, product = 1, res = 0;
        while (hi < nums.length) {
            product *= nums[hi];
            while (li <= hi && product >= k)
                product /= nums[li++];
            res += hi - li + 1;
            hi++;
        }
        return res;
    }
}
