package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] nums = {0, 1, 2};
        int target = 3;
        System.out.println(threeSumClosest(nums, target));
    }

    public static int threeSumClosest(int[] nums, int target) {
        int min = Integer.MAX_VALUE, res = 0;
        Arrays.sort(nums);
        int last = nums[0] - 1;
        for (int i = 0; i < nums.length - 2; i++) {
            if (nums[i] == last) continue;
            last = nums[i];
            int li = i + 1, hi = nums.length - 1;
            while (li < hi) {
                int sum = nums[i] + nums[li] + nums[hi];
                if (sum == target) return target;
                if (min > Math.abs(sum - target)) {
                    min = Math.abs(sum - target);
                    res = sum;
                }
                if (sum > target) hi--;
                else li++;
            }
        }
        return res;
    }
}
