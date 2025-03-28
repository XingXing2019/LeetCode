package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        int[] answers = {1, 1, 1, 2};
        System.out.println(numRabbits(answers));
    }
    public static int numRabbits(int[] answers) {
        Map<Integer, Integer> map = new HashMap<>();
        for (int a : answers)
            map.put(a, map.getOrDefault(a, 0) + 1);
        int res = 0;
        for (int key : map.keySet())
            res += (key + 1) * (map.get(key) % (key + 1) == 0 ? map.get(key) / (key + 1) : map.get(key) / (key + 1) + 1);
        return res;
    }
}
