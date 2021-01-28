package com.company;

import java.util.HashMap;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean hasGroupsSizeX(int[] deck) {
        HashMap<Integer, Integer> map = new HashMap<>();
        int k = 0;
        for (int num : deck){
            if(!map.containsKey(num))
                map.put(num, 0);
            map.put(num, map.get(num) + 1);
        }
        for (var kv : map.entrySet())
            k = gcd(k, kv.getValue());
        return k > 1;
    }

    public int gcd(int a, int b){
        return a % b == 0 ? b : gcd(b, a % b);
    }
}
