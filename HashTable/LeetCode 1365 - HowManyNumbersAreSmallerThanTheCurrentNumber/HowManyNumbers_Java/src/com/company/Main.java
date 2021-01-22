package com.company;

import java.util.Arrays;
import java.util.HashMap;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int[] smallerNumbersThanCurrent_N(int[] nums) {
        var max = 0;
        for (int num : nums)
            max = Math.max(max, num);
        int[] record = new int[max + 1];
        for (int num : nums)
            record[num]++;
        int[] smaller = new int[max + 1];
        for (int i = 1; i < smaller.length; i++)
            smaller[i] = smaller[i - 1] + record[i - 1];
        for (int i = 0; i < nums.length; i++)
            nums[i] = smaller[nums[i]];
        return nums;
    }

    public int[] smallerNumbersThanCurrent_NLogN(int[] nums) {
        int[] cloned = nums.clone();
        Arrays.sort(cloned);
        HashMap<Integer, Integer> map = new HashMap<>();
        for (int i = 0; i < cloned.length; i++) {
            if(!map.containsKey(cloned[i]))
                map.put(cloned[i], i);
        }
        for (int i = 0; i < nums.length; i++)
            nums[i] = map.get(nums[i]);
        return nums;
    }
}
