package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int maxOperations(int[] nums, int k) {
        Map<Integer, Integer> map = new HashMap<>();
        int res = 0;
        for (int num : nums) {
            if (map.getOrDefault(k - num, 0) != 0) {
                res++;
                map.put(k - num, map.getOrDefault(k - num, 0) - 1);
            } else
                map.put(num, map.getOrDefault(num, 0) + 1);
        }
        return res;
    }
}
