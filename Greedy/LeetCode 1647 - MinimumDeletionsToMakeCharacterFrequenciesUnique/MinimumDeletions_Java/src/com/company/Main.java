package com.company;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int minDeletions(String s) {
        int res = 0;
        Map<Character, Integer> map = new HashMap<>();
        HashSet<Integer> set = new HashSet<>();
        for (Character l : s.toCharArray())
            map.put(l, map.getOrDefault(l, 0) + 1);
        for (Character l : map.keySet()) {
            int temp = map.get(l);
            while (!set.add(temp) && temp > 0)
                temp--;
            res += map.get(l) - temp;
        }
        return res;
    }
}
