package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }

    public boolean confusingNumber(int n) {
        Map<Integer, Integer> map = new HashMap<>();
        map.put(0, 0);
        map.put(1, 1);
        map.put(6, 9);
        map.put(8, 8);
        map.put(9, 6);
        int copy = n, rotated = 0;
        while (copy != 0) {
            int digit = copy % 10;
            if (!map.containsKey(digit))
                return false;
            rotated = rotated * 10 + map.get(digit);
            copy /= 10;
        }
        return rotated != n;
    }
}
