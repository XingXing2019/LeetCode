package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[] rains = {1,0,2,0,2,1};
        System.out.println(avoidFlood(rains));
    }

    public static int[] avoidFlood(int[] rains) {
        int[] res = new int[rains.length];
        Map<Integer, Integer> lakes = new HashMap<>();
        List<Integer> noRainDays = new ArrayList<>();
        for (int i = rains.length - 1; i >= 0; i--) {
            if (rains[i] == 0)
                noRainDays.add(0, i);
            else {
                res[i] = -1;
                if (lakes.containsKey(rains[i])) {
                    int index = Collections.binarySearch(noRainDays, lakes.get(rains[i]));
                    if (index < 0) index = ~index;
                    if (index == 0) return new int[0];
                    res[noRainDays.get(index - 1)] = rains[i];
                    noRainDays.remove(index - 1);
                }
                lakes.put(rains[i], i);
            }
        }
        for (int day : noRainDays)
            res[day] = 1;
        return res;
    }
}
