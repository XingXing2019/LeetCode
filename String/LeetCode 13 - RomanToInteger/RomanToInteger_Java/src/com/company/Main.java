package com.company;

import java.util.HashMap;

public class Main {

    public static void main(String[] args) {
	// write your code here
    }
    public int romanToInt(String s) {
        HashMap<Character, Integer> map = new HashMap<Character, Integer>(){{
            put('I', 1);
            put('V', 5);
            put('X', 10);
            put('L', 50);
            put('C', 100);
            put('D', 500);
            put('M', 1000);
        }};
        int[] digits = new int[s.length()];
        for (int i = 0; i < s.length(); i++) {
            digits[i] = map.get(s.charAt(i));
            if(i != 0 && map.get(s.charAt(i - 1)) < map.get(s.charAt(i)))
                digits[i - 1] *= -1;
        }
        int res = 0;
        for (int i = 0; i < digits.length; i++)
            res += digits[i];
        return res;
    }
}
