package com.company;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int numberOfArithmeticSlices(int[] nums) {
        if (nums.length < 3) return 0;
        int res = 0, li = 0, hi = 1, diff = nums[hi] - nums[li];
        while (hi < nums.length) {
            if (nums[hi] - nums[hi - 1] != diff) {
                if (hi - li >= 3)
                    res += (hi - li - 1) * (hi - li - 2) / 2;
                li = hi - 1;
                diff = nums[hi] - nums[li];
            }
            hi++;
        }
        if (hi - li < 3) return res;
        res += (hi - li - 1) * (hi - li - 2) / 2;
        return res;
    }
}
