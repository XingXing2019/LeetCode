package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int minSubarray(int[] nums, int p) {
        long sum = 0, prefix = 0;
        int res = nums.length;
        for (int num : nums)
            sum += num;
        long mod = sum % p;
        if (mod == 0) return 0;
        Map<Long, Integer> map = new HashMap<>();
        map.put(0l, -1);
        for (int i = 0; i < nums.length; i++) {
            prefix += nums[i];
            long target = prefix % p - mod;
            if (target < 0) target += p;
            if (map.containsKey(target))
                res = Math.min(res, i - map.get(target));
            map.put(prefix % p, i);
        }
        return res == nums.length ? -1 : res;
    }
}
