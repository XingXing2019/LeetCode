package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int findLHS(int[] nums) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int num : nums)
            map.put(num, map.getOrDefault(num, 0) + 1);
        int res = 0;
        for (int num : map.keySet()){
            if (map.containsKey(num + 1))
                res = Math.max(res, map.get(num) + map.get(num + 1));
        }
        return res;
    }
}
