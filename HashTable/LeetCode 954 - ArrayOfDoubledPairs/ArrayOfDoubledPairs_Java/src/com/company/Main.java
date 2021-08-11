package com.company;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        int[] arr = {4, -2, 2, -4};
        System.out.println(canReorderDoubled(arr));
    }

    public static boolean canReorderDoubled(int[] arr) {
        Arrays.sort(arr);
        Map<Double, Integer> map = new HashMap<>();
        for (double num : arr){
            double key = num > 0 ? num / 2 : num * 2;
            if(map.containsKey(key)){
                map.put(key, map.get(key) - 1);
                if(map.get(key) == 0)
                    map.remove(key);
            }
            else
                map.put(num, map.getOrDefault(num, 0) + 1);
        }
        return map.size() == 0;
    }
}
