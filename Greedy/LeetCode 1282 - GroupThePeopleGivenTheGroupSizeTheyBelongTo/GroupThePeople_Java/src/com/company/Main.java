package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        // write your code here
    }

    public List<List<Integer>> groupThePeople(int[] groupSizes) {
        Map<Integer, List<Integer>> map = new HashMap<>();
        for (int i = 0; i < groupSizes.length; i++) {
            if (!map.containsKey(groupSizes[i]))
                map.put(groupSizes[i], new ArrayList<>());
            map.get(groupSizes[i]).add(i);
        }
        List<List<Integer>> res = new ArrayList<>();
        for (int key : map.keySet()) {
            List<Integer> group = new ArrayList<>();
            for (int i = 1; i <= map.get(key).size(); i++) {
                group.add(map.get(key).get(i - 1));
                if (i % key == 0) {
                    res.add(group);
                    group = new ArrayList<>();
                }
            }
        }
        return res;
    }
}
