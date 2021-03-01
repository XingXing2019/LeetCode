package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int distributeCandies(int[] candyType) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int c : candyType)
            map.put(c, map.getOrDefault(c, 0) + 1);
        return Math.min(map.size(), candyType.length / 2);
    }
}
