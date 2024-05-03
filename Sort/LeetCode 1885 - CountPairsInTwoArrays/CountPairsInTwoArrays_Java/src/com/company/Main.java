package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public long countPairs(int[] nums1, int[] nums2) {
        var diff = new int[nums1.length];
        for (int i = 0; i < nums1.length; i++)
            diff[i] = nums1[i] - nums2[i];
        Arrays.sort(diff);
        var res = 0L;
        for (var num : diff) {
            var index = binarySearch(diff, -num);
            res += num > 0 ? diff.length - index - 1 : diff.length - index;
        }
        return res / 2;
    }

    public int binarySearch(int[] nums, int target) {
        int li = 0, hi = nums.length - 1;
        while (li <= hi) {
            var mid = li + (hi - li) / 2;
            if (nums[mid] <= target)
                li = mid + 1;
            else
                hi = mid - 1;
        }
        return li;
    }
}
