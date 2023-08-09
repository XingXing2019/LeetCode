package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minimizeMax(int[] nums, int p) {
        Arrays.sort(nums);
        int li = 0, hi = nums[nums.length - 1] - nums[0];
        while (li <= hi) {
            int mid = li + (hi - li) / 2;
            if (isValid(nums, mid, p))
                hi = mid - 1;
            else
                li = mid + 1;
        }
        return li;
    }

    public boolean isValid(int[] nums, int mid, int p) {
        for (int i = 1; i < nums.length; i++) {
            if (nums[i] - nums[i - 1] <= mid) {
                p--;
                i++;
            }
        }
        return p <= 0;
    }
}
