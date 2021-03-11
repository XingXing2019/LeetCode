package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int numPairsDivisibleBy60(int[] time) {
        Map<Integer, Integer> map = new HashMap<>();
        int res = 0;
        for (int t : time){
            int mod = t % 60;
            int temp = mod == 0 ? 60 : mod;
            res += map.getOrDefault(60 - temp, 0);
            map.put(mod, map.getOrDefault(mod, 0) + 1);
        }
        return res;
    }
}
