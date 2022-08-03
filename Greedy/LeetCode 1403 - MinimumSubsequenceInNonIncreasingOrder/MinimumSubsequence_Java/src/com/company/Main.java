package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public List<Integer> minSubsequence(int[] nums) {
        Arrays.sort(nums);
        List<Integer> res = new ArrayList<>();
        int sum = 0, left = 0;
        for (int num : nums)
            left += num;
        for (int i = nums.length - 1; i >= 0; i--) {
            res.add(nums[i]);
            sum += nums[i];
            left -= nums[i];
            if (left >= sum) continue;
            return res;
        }
        return res;
    }
}
