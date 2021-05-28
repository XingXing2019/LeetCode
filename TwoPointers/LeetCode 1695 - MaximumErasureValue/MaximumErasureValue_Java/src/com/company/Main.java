package com.company;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int maximumUniqueSubarray_map(int[] nums) {
        int li = 0, hi = 0, sum = 0, res = 0;
        Map<Integer, Integer> map = new HashMap<>();
        while (hi < nums.length) {
            map.put(nums[hi], map.getOrDefault(nums[hi], 0) + 1);
            if (map.get(nums[hi]) > 1) {
                res = Math.max(res, sum);
                while (map.get(nums[hi]) > 1) {
                    sum -= nums[li];
                    map.put(nums[li], map.get(nums[li]) - 1);
                    li++;
                }
            }
            sum += nums[hi];
            hi++;
        }
        res = Math.max(res, sum);
        return res;
    }

    public int maximumUniqueSubarray_set(int[] nums) {
        int li = 0, hi = 0, sum = 0, res = 0;
        HashSet<Integer> set = new HashSet<>();
        while (hi < nums.length) {
            while (set.contains(nums[hi])){
                set.remove(nums[li]);
                sum -= nums[li++];
            }
            set.add(nums[hi]);
            sum += nums[hi++];
            res = Math.max(res, sum);
        }
        return res;
    }
}
