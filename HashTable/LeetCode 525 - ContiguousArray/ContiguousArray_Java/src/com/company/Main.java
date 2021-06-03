package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public int findMaxLength(int[] nums) {
        int diff = 0, res = 0;
        Map<Integer, Integer> map = new HashMap<>();
        map.put(0, -1);
        for (int i = 0; i < nums.length; i++) {
            diff += nums[i] == 0 ? 1 : -1;
            if (map.containsKey(diff))
                res = Math.max(res, i - map.get(diff));
            else
                map.put(diff, i);
        }
        return res;
    }
}
