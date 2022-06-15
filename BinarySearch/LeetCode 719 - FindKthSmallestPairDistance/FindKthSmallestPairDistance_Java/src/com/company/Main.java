package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1, 3, 1};
        int k = 3;
        System.out.println(smallestDistancePair(nums, k));
    }

    public static int smallestDistancePair(int[] nums, int k) {
        Arrays.sort(nums);
        int li = 0, hi = nums[nums.length - 1] - nums[0];
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            int count = count(nums, mid);
            if (count < k)
                li = mid + 1;
            else
                hi = mid - 1;
        }
        return li;
    }

    public static int count(int[] nums, int target) {
        int li = 0, hi = 0, res = 0;
        while (hi < nums.length) {
            while (li < hi && nums[hi] - nums[li] > target)
                li++;
            res += hi - li;
            hi++;
        }
        return res;
    }
}
