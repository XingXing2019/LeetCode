package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int numSubseq(int[] nums, int target) {
        Arrays.sort(nums);
        long mod = 1_000_000_000 + 7, res = 0;
        long[] power = new long[nums.length];
        for (int i = 0; i < power.length; i++)
            power[i] = i == 0 ? 1 : power[i - 1] * 2 % mod;
        for (int i = 0; i < nums.length; i++) {
            if (target - nums[i] < nums[i]) break;
            int index = binarySearch(nums, target - nums[i]);
            res += power[index - i] % mod;
        }
        return (int)(res % mod);
    }

    public int binarySearch(int[] nums, int target){
        int li = 0, hi = nums.length - 1;
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            if (nums[mid] <= target)
                li = mid + 1;
            else
                hi = mid - 1;
        }
        return hi;
    }
}
