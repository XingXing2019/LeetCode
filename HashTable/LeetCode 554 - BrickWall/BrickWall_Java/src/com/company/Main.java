package com.company;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public int leastBricks(List<List<Integer>> wall) {
        Map<Integer, Integer> map = new HashMap<>();
        int max = 0;
        for (List<Integer> row : wall){
            int temp = 0;
            for (int i = 0; i < row.size() - 1; i++) {
                temp += row.get(i);
                map.put(temp, map.getOrDefault(temp, 0) + 1);
                max = Math.max(max, map.get(temp));
            }
        }
        return wall.size() - max;
    }
}
