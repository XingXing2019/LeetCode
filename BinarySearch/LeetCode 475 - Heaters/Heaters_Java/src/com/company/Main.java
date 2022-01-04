package com.company;

import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
        int[] house = {1, 2, 3};
        int[] heaters = {2};
        System.out.println(findRadius(house, heaters));
    }

    public static int findRadius(int[] houses, int[] heaters) {
        Arrays.sort(houses);
        Arrays.sort(heaters);
        int res = 0;
        for (int house : houses) {
            int index = Arrays.binarySearch(heaters, house);
            if (index >= 0) continue;
            index = ~index;
            int before = index == 0 ? Integer.MAX_VALUE : house - heaters[index - 1];
            int after = index >= heaters.length ? Integer.MAX_VALUE : heaters[index] - house;
            res = Math.max(res, Math.min(before, after));
        }
        return res;
    }
}
