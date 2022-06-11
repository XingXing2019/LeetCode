package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        int[] nums = {1, 1};
        int x = 3;
        System.out.println(minOperations(nums, x));
    }

    public static int minOperations(int[] nums, int x) {
        int len = nums.length, res = Integer.MAX_VALUE;
        int[] prefix = new int[len];
        int[] suffix = new int[len];
        Map<Integer, Integer> index = new HashMap<>();
        for (int i = 0; i < nums.length; i++) {
            prefix[i] = i == 0 ? nums[i] : nums[i] + prefix[i - 1];
            if (prefix[i] == x)
                res = Math.min(res, i + 1);
            suffix[len - i - 1] = i == 0 ? nums[len - 1] : nums[len - i - 1] + suffix[len - i];
            if (suffix[len - i - 1] == x)
                res = Math.min(res, i + 1);
            index.put(suffix[len - i - 1], len - i - 1);
        }
        for (int i = 0; i < prefix.length; i++) {
            if (index.containsKey(x - prefix[i]) && i != index.get(x - prefix[i])) {
                res = Math.min(res, (i + 1) + (len - index.get(x - prefix[i])));
            }
        }
        return res == Integer.MAX_VALUE ? -1 : res;
    }
}
